using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.ContextModels
{
    public record PostingReference(
    Guid ReferenceId,
    AccountSourceType AccountSource,
    Guid? WarehouseId = null
        );
    public class TaxDetail
    {
        public Guid TaxCode { get; set; }
        public decimal Amount { get; set; }
    }
    public class PostingContext
    {
        public string OperationCode { get; init; } = null!;
        public Guid DocumentId { get; init; }
        public DateTime Date { get; init; }
        public Guid BranchId { get; init; }
        public Guid Payable { get; init; }
        public string? Note { get; set; }


        public List<TaxDetail> Taxes { get; set; } = new();
        public PaymentInfo PaymentMethod { get; set; }
        public OperationContext CurrencyContext { get; init; } = null!;
        public decimal NetAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CostAmount { get; set; }
        public Dictionary<AmountSourceType, decimal> Amounts { get; } = new();
        public Dictionary<AccountSourceType, List<PostingReference>> References { get; } = new();
        public Dictionary<Guid, decimal> DynamicAmounts { get; } = new();
        public void AddAmount(AmountSourceType type, decimal value)
        {
            var roundedValue = Math.Round(value, 4, MidpointRounding.AwayFromZero);
            if (roundedValue == 0) return;
            Amounts[type] = roundedValue;
        }
        public void AddDynamicAmount(Guid id, decimal amount) => 
            DynamicAmounts[id] = Math.Round(amount, 4, MidpointRounding.AwayFromZero);
        
        public void AddReference(AccountSourceType type, Guid referenceId, Guid? warehouseId = null)
        {
            if (!References.ContainsKey(type))
                References[type] = new List<PostingReference>();

            References[type].Add(new PostingReference(referenceId, type, warehouseId));
        }
        public decimal GetAmount(AmountSourceType type) =>
            Amounts.TryGetValue(type, out var value) ? value : 0;
    }


}



