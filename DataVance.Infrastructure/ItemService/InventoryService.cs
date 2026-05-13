using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.PurchaseTransactions.DTO;
using DataVance.Application.Features.PurchaseTransactions.Service;
using DataVance.Domain.Common;
using DataVance.Domain.Entities.ItemSystem.ItemEntity;
using DataVance.Domain.Warehousing.Enums;
using DataVance.Domain.Warehousing.Inventory;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.ItemService
{
    public class InventoryService : IInventoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InventoryService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(ApplicationDbContext context, ILogger<InventoryService> logger, IUnitOfWork unitOfWork)
        {
            _context = context;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public async Task UpdateBalanceAsync(Guid branchId, Guid warehouseId, Guid itemId, decimal qtyChange, decimal? unitCost = null)
        {
            // 1. Ã·» «·”Ã· (»œÊ‰ NoTracking ·√‰‰« ”‰⁄œ· ⁄·ÌÂ)
            var balance = await _context.InventoryBalances
                .FirstOrDefaultAsync(b => b.BranchId == branchId &&
                                          b.WarehouseId == warehouseId &&
                                          b.ItemId == itemId);

            try
            {
                if (balance == null)
                {
                    // Õ«·… ≈÷«›… ’‰› ·√Ê· „—… ›Ì Â–« «·„Œ“‰
                    if (qtyChange < 0) throw new Exception("·« Ì„ﬂ‰ ”Õ» ’‰› ·Ì” ·Â —’Ìœ √’·«");

                    balance = new InventoryBalance(itemId, warehouseId, branchId, qtyChange, unitCost ?? 0);
                    _context.InventoryBalances.Add(balance);
                }
                else
                {
                    //  ÕœÌÀ ”Ã· „ÊÃÊœ
                    if (qtyChange > 0)
                        balance.AddStock(qtyChange, unitCost ?? 0);
                    else
                        balance.RemoveStock(Math.Abs(qtyChange));
                }

                // 2. «·Õ›Ÿ (Â‰« Ì·⁄» RowVersion œÊ— «·Õ«—”)
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // 3. ≈–« ÕœÀ  ÷«—» („ÊŸ› ¬Œ— ⁄œ· «·—’Ìœ ›Ì ‰›” «··ÕŸ…)
                // «·Õ·: ≈⁄«œ… «·„Õ«Ê·… (Retry) ·„—… Ê«Õœ… √Ê ≈»·«€ «·„” Œœ„
                throw new Exception("ÕœÀ  ÕœÌÀ „ “«„‰ ⁄·Ï «·—’Ìœ° Ì—ÃÏ ≈⁄«œ… «·„Õ«Ê·….");
            }
        }
        public async Task<bool> AddStockAsync(InventoryRequest req, CancellationToken ct = default)
        {

            var item = await _context.Items.FindAsync(new object[] { req.ItemId }, ct);
            if (item == null || !item.IsActive)
                throw new InvalidOperationException("«·’‰› €Ì— „ÊÃÊœ √Ê €Ì— ‰‘ÿ");

            if (!item.IsStockable)
                return true; // «·√’‰«› €Ì— «·„Œ“‰Ì… ·«  Õ «Ã · ÕœÌÀ √—’œ…

            // 2.  ”ÃÌ· «·Õ—ﬂ…
            var movement = new InventoryMovement(
                req.BranchId, req.WarehouseId, req.ItemId,
                req.BatchNumber, req.ExpiryDate,
                req.Type, req.DocumentNo, req.DocumentId,
                req.Quantity, req.UnitId, req.ConversionFactor,
                req.UnitCost, req.UserId, req.Remarks);

            _context.InventoryMovements.Add(movement);

            // 3.  ÕœÌÀ «·—’Ìœ
            var balance = await GetOrCreateBalance(req, ct);
            balance.AddStock(movement.BaseQuantity, req.UnitCost);

            // 4. ≈ÿ·«ﬁ «·√Õœ«À (Domain Events)
            // ‰ Õﬁﬁ ≈–« ﬂ«‰ «·—’Ìœ «·≈Ã„«·Ì ›Ì Â–« «·„Œ“‰ Ê’· ·Õœ ≈⁄«œ… «·ÿ·»
            balance.CheckReorderPoint(item.ReorderPoint);
            //3.«· √ﬂœ „‰ «·Ê—«À…

            _logger.LogInformation("Stock updated and events dispatched for Item {ItemId}", item.Id);
            return true;
        }

        public async Task<bool> RemoveStockAsync(InventoryRequest req, CancellationToken ct = default)
        {
            decimal baseQtyToRemove = req.Quantity * req.ConversionFactor;

            // 1. «· Õﬁﬁ „‰ ÊÃÊœ —’Ìœ ﬂ«›Ú
            //var balance = await _context.InventoryBalances
            //    .FirstOrDefaultAsync(x => x.ItemId == req.ItemId &&
            //                              x.WarehouseId == req.WarehouseId &&
            //                              x.BatchNumber == req.BatchNumber, ct);
            var balance = await _context.InventoryBalances
                 .FirstOrDefaultAsync(x => x.ItemId == req.ItemId &&
                                x.WarehouseId == req.WarehouseId &&
                                x.BranchId == req.BranchId && // ÷—Ê—Ì Ãœ«
                                x.BatchNumber == req.BatchNumber, ct);

            if (balance == null || balance.Quantity < baseQtyToRemove)
            {
                _logger.LogWarning("Insufficient stock for Item {Item}", req.ItemId);
                throw new InvalidOperationException($"«·—’Ìœ €Ì— ﬂ«›Ú ··’‰› «·„Œ «— (Batch: {req.BatchNumber ?? "N/A"})");
            }

            // 2.  ”ÃÌ· Õ—ﬂ… «·’—› (»ﬂ„Ì… ”«·»…)
            var movement = new InventoryMovement(
                req.BranchId, req.WarehouseId, req.ItemId,
                req.BatchNumber, req.ExpiryDate,
                req.Type, req.DocumentNo, req.DocumentId,
                -req.Quantity, //  Œ“‰ ”«·»… ›Ì ”Ã·«  «·Õ—ﬂ… ·»Ì«‰ «·‰ﬁ’
                req.UnitId, req.ConversionFactor,
                req.UnitCost, req.UserId, req.Remarks);

            _context.InventoryMovements.Add(movement);

            // 3. Œ’„ „‰ «·—’Ìœ «··ÕŸÌ
            balance.RemoveStock(baseQtyToRemove);
            //balance.RemoveStock(baseQtyToRemove, req.UnitCost);

            return true;
        }


        public async Task<bool> TransferStockAsync(TransferRequest req, CancellationToken ct = default)
        {
            //  „‰⁄ «· ÕÊÌ· ·‰›” «·„ﬂ«‰
            if (req.FromWarehouseId == req.ToWarehouseId)
                throw new InvalidOperationException("·« Ì„ﬂ‰ «· ÕÊÌ· ·‰›” «·„Œ“‰");


            //Dirty Read(ﬁ—«¡… »Ì«‰«  „ƒﬁ … ﬁœ Ì „ «· —«Ã⁄ ⁄‰Â«).IsolationLevel
            //await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted,req.BranchId, ct);
            // 2. «” Œœ«„ Transaction ·÷„«‰ –—Ì… «·⁄„·Ì… (Atomicity)
            // „·«ÕŸ…: «·‹ Transaction Ì „ ≈œ«— Â« ⁄«œ… ›Ì «·‹ Handler° 
            // ·ﬂ‰ «·Œœ„… ÌÃ» √‰  œ⁄„ –·ﬂ.

            // 3.  ‰›Ì– «·Œ’„ Ê«·≈÷«›…
            // ‰” Œœ„ ABS ··ﬂ„Ì… ·÷„«‰ ⁄œ„  „—Ì— ﬁÌ„ ”«·»… »«·Œÿ√ „‰ «·Ê«ÃÂ…
            var cleanQty = Math.Abs(req.Quantity);

            await RemoveStockAsync(req.ToInventoryRequest(req.FromWarehouseId, MovementType.StockTransferOut), ct);
            await AddStockAsync(req.ToInventoryRequest(req.ToWarehouseId, MovementType.StockTransferIn), ct);

            return true;
        }


        private async Task<InventoryBalance> GetOrCreateBalance(InventoryRequest req, CancellationToken ct)
        {
            //  Õ”Ì‰: «·»ÕÀ »«” Œœ«„ FirstOrDefaultAsync „⁄   »⁄ (Tracking) 
            // ·÷„«‰ √‰ «· ⁄œÌ·«  ” ıÕ›Ÿ ⁄‰œ ⁄„· SaveChanges
            var balance = await _context.InventoryBalances
                .FirstOrDefaultAsync(x => x.ItemId == req.ItemId &&
                                          x.WarehouseId == req.WarehouseId &&
                                          x.BatchNumber == req.BatchNumber, ct);

            if (balance == null)
            {
                //  Õﬁﬁ ≈÷«›Ì: Â· «·’‰› Ì ÿ·» Batch/Expiryø
                // var item = await _context.Items.FindAsync(req.ItemId);

                balance = new InventoryBalance(req.ItemId, req.WarehouseId, req.BatchNumber, req.ExpiryDate);
                _context.InventoryBalances.Add(balance);
            }

            return balance;
        }
    }
}

//public async Task<bool> AddStockAsync(InventoryRequest req, CancellationToken ct = default)
//{
//    // 1.  ”ÃÌ· «·Õ—ﬂ… (Movement) - ”Ã·  «—ÌŒÌ €Ì— ﬁ«»· ·· ⁄œÌ·
//    var movement = new InventoryMovement(
//        req.BranchId, req.WarehouseId, req.ItemId,
//        req.BatchNumber, req.ExpiryDate,
//        req.Type, req.DocumentNo, req.DocumentId,
//        req.Quantity, req.UnitId, req.ConversionFactor,
//        req.UnitCost, req.UserId, req.Remarks);

//    _context.InventoryMovements.Add(movement);

//    // 2.  ÕœÌÀ «·—’Ìœ (Balance) - «·Õ«·… «··ÕŸÌ… ··„Œ“‰
//    var balance = await GetOrCreateBalance(req, ct);

//    balance.AddStock(movement.BaseQuantity, req.UnitCost);

//    _logger.LogInformation("Stock Added: Item {ItemId}, Qty {Qty}, Warehouse {WhId}",
//        req.ItemId, movement.BaseQuantity, req.WarehouseId);

//    return true;
//}
//private async Task<InventoryBalance> GetOrCreateBalance(InventoryRequest req, CancellationToken ct)
//{
//    var balance = await _context.InventoryBalances
//        .FirstOrDefaultAsync(x => x.ItemId == req.ItemId &&
//                                  x.WarehouseId == req.WarehouseId &&
//                                  x.BatchNumber == req.BatchNumber, ct);

//    if (balance == null)
//    {
//        balance = new InventoryBalance(req.ItemId, req.WarehouseId, req.BatchNumber, req.ExpiryDate);
//        _context.InventoryBalances.Add(balance);
//    }

//    return balance;
//}
//public async Task<bool> TransferStockAsync(TransferRequest req, CancellationToken ct = default)
//{
//    // ⁄„·Ì… «· ÕÊÌ· ÂÌ ⁄»«—… ⁄‰ (Remove) „‰ „Œ“‰ «·„’œ— Ê (Add) ›Ì „Œ“‰ «·Âœ›
//    // ‰” Œœ„ ‰›” «·„‰ÿﬁ ·÷„«‰ «·‹ Consistency

//    // 1. «·Œ’„ „‰ «·„’œ—
//    await RemoveStockAsync(req.ToInventoryRequest(req.FromWarehouseId, MovementType.StockTransferOut), ct);

//    // 2. «·≈÷«›… ··Âœ›
//    await AddStockAsync(req.ToInventoryRequest(req.ToWarehouseId, MovementType.StockTransferIn), ct);

//    return true;
//}
