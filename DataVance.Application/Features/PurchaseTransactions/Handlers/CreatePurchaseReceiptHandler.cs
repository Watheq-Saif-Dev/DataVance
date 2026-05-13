using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.PurchaseTransactions.Commend;
using DataVance.Application.Features.PurchaseTransactions.DTO;
using DataVance.Application.Features.PurchaseTransactions.Service;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Warehousing.Enums;
using DataVance.Domain.Warehousing.Movements.PurchaseSystem;
using DataVance.Domain.Warehousing.Setup.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.PurchaseTransactions.Handlers
{

    public class CreatePurchaseReceiptHandler : IRequestHandler<CreatePurchaseReceiptCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IInventoryService _inventoryService;

        public CreatePurchaseReceiptHandler(IApplicationDbContext context, IInventoryService inventoryService)
        {
            _context = context;
            _inventoryService = inventoryService;
        }

        public async Task<bool> Handle(CreatePurchaseReceiptCommand request, CancellationToken ct)
        {
            var operationContext = new OperationContext(

                request.CurrencyId,
                request.ExchangeRate,
                request.CurrCode
            );
            var paymentInf = new PaymentInfo(
                request.PaymentMethod,
                request.FinancialAccountId,
                request.PaymentReferenceNo);
            var receipt = new PurchaseReceipt(
                request.ReceiptNo,
                request.VendorId,
                operationContext,
                "«” ·«„ „‘ —Ì« ",
                request.warehouseId,
                paymentInf
            );
            receipt.UpdateHeaderDiscount(request.HeaderDiscount);
            foreach (var item in request.Items)
            {

                var lis = new List<LinkTax>();
                receipt.AddLine(
                    item.ItemId,
                    item.WarehouseId,
                    item.UnitId,
                    item.Quantity,
                    item.UnitCost,
                    item.ConversionFactor,
                    item.BatchNumber,
                    item.ExpiryDate,
                    lis
                );
                decimal netUnitCost = item.UnitCost - item.DiscountAmountForUnit;

                var invReq = new InventoryRequest(
                    request.BranchId,
                    item.WarehouseId,
                    item.ItemId,
                    item.UnitId,
                    item.Quantity,
                    item.ConversionFactor,
                    netUnitCost,
                    MovementType.PurchaseReceipt,
                    receipt.ReceiptNo,
                    receipt.Id,
                    request.UserId,
                    item.BatchNumber,
                    item.ExpiryDate
                );

                await _inventoryService.AddStockAsync(invReq, ct);
            }
            _context.PurchaseReceipts.Add(receipt);
            receipt.Confirm();

            return true;
        }
    }

}



