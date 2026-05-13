using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Common.Models;
using DataVance.Application.Features.PurchaseTransactions.Service;
using DataVance.Application.Features.RuleEngine.Specifications;
using DataVance.Domain.Finance.Rules.Events;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.ContextBuilders.Purchase
{
    public class PurchaseReceiptContextBuilder : IPostingContextBuilder
    {
        private readonly IPurchaseAccountingRepository _receiptRepo;

        public PurchaseReceiptContextBuilder(IPurchaseAccountingRepository receiptRepo)
        {
            _receiptRepo = receiptRepo;
        }

        public string OperationCode => "PUR_RCT";

        public async Task<Result<PostingContext>> BuildAsync(Guid documentId, Guid branchId, CancellationToken ct)
        {
            var receipt = await _receiptRepo.GetPurchase(documentId, ct);
            if (receipt == null || receipt.BranchId != branchId)
                return Result<PostingContext>.Failure($"Purchase receipt not found for ID {documentId} or branch mismatch.");

            var netAmount = receipt.TotalAmount + receipt.TotalTax - receipt.HeaderDiscount;

            var postingContext = new PostingContext
            {
                OperationCode = this.OperationCode,
                DocumentId = receipt.Id,
                Date = receipt.ReceiptDate,
                CurrencyContext = receipt.Context,
                PaymentMethod = receipt.Payment,
                Note = receipt.Remarks ?? $"Purchase Receipt No: {receipt.ReceiptNo}",
                Payable = receipt.VendorId,
                NetAmount = netAmount,
                TotalAmount = receipt.TotalAmount,
                TaxAmount = receipt.TotalTax,
                DiscountAmount = receipt.HeaderDiscount
            };

            postingContext.AddReference(AccountSourceType.Warehouse, receipt.WarehouseId, receipt.WarehouseId);

                var taxGroups = TaxGroupingSpec.GroupTaxes(receipt.Lines);

                foreach (var taxDetail in taxGroups)
                {
                    postingContext.DynamicAmounts[taxDetail.TaxCode] = taxDetail.Amount;
                    postingContext.AddReference(AccountSourceType.TaxCode, taxDetail.TaxCode);
                }

            return Result<PostingContext>.Success(postingContext);
        }
    }
}

