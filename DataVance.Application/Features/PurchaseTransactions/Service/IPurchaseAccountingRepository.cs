using DataVance.Application.Features.PurchaseTransactions.DTO;
using DataVance.Domain.Warehousing.Movements.PurchaseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.PurchaseTransactions.Service
{
    public interface IPurchaseAccountingRepository
    {
        Task<PurchaseReceiptAccountingDto?> GetReceiptForAccountingAsync(Guid receiptId, CancellationToken ct);
        Task<PurchaseReceipt?> GetPurchase(Guid receiptId, CancellationToken ct);
    }
}

