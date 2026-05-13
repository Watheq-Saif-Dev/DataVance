using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.AmountResolvers
{
    public class AmountResolver
    {
        public decimal ResolveAmount(AccountingRuleLine line, PostingContext context, Guid? currentReferenceId = null)
        {
            decimal amount = 0;

            if (currentReferenceId.HasValue && context.DynamicAmounts.TryGetValue(currentReferenceId.Value, out var dynamicAmount))
            {
                amount = dynamicAmount;
            }
            else
            {
                amount = line.AmountSourceType switch
                {
                    AmountSourceType.FullAmount => context.TotalAmount,
                    AmountSourceType.CostAmount => context.CostAmount,
                    AmountSourceType.NetAmount => context.NetAmount,
                    AmountSourceType.TaxAmount => context.TaxAmount,
                    AmountSourceType.DiscountAmount => context.DiscountAmount,
                    _ => context.GetAmount(line.AmountSourceType)
                };
            }

            // تطبيق المنطق الذهبي: الدقة 0.0001m والتقريب المهني
            return Math.Round(amount, 4, MidpointRounding.AwayFromZero);
        }
    }
}

