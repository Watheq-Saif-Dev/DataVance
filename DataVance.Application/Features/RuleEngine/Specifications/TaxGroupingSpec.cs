using System;
using System.Collections.Generic;
using System.Linq;
using DataVance.Domain.Finance.Rules.Events;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Warehousing.Movements.PurchaseSystem;

namespace DataVance.Application.Features.RuleEngine.Specifications
{
    public static class TaxGroupingSpec
    {
        public static List<TaxDetail> GroupTaxes(IEnumerable<PurchaseReceiptLine> lines)
        {
            if (lines == null || !lines.Any())
                return new List<TaxDetail>();

            return lines
                .Where(line => line.Taxes != null)
                .SelectMany(line => line.Taxes)
                .GroupBy(t => t.TaxCodeId)
                .Select(g => new TaxDetail
                {
                    TaxCode = g.Key,
                    Amount = g.Sum(t => t.Amount)
                })
                .ToList();
        }
    }
}
