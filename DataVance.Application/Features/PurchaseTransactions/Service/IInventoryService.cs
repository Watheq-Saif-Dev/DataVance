using DataVance.Application.Features.PurchaseTransactions.DTO;
using DataVance.Domain.Entities.ItemSystem.ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.PurchaseTransactions.Service
{
    public interface IInventoryService
    {
        Task<bool> AddStockAsync(InventoryRequest req, CancellationToken ct = default);
        Task<bool> RemoveStockAsync(InventoryRequest req, CancellationToken ct = default);
        Task<bool> TransferStockAsync(TransferRequest req, CancellationToken ct = default);
    }
}
