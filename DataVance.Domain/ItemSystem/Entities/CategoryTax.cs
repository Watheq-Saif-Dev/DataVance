
using DataVance.Domain.Common;

namespace DataVance.Domain.ItemSystem.Entities
{
    public class CategoryTax
    {
        public Guid ItemGroupId { get; private set; }
        public Guid TaxCodeId { get; private set; }
        public int CalculationOrder { get; private set; }

        protected CategoryTax() { }

        public CategoryTax(Guid taxCodeId, int calculationOrder = 1)
        {
            if (taxCodeId == Guid.Empty) throw new ArgumentException("TaxCodeId must be valid.");

            TaxCodeId = taxCodeId;
            CalculationOrder = calculationOrder;
        }

        public void ChangeCalculationOrder(int newOrder)
        {
            CalculationOrder = newOrder;
        }
    }
}

