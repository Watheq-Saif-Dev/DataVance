using DataVance.Domain.Common;

namespace DataVance.Domain.ItemSystem.Entities
{
    public class ItemTax : BaseEntity
    {

        public Guid ItemId { get; private set; }
        public Guid TaxCodeId { get; private set; } // نشير للضريبة بالـ ID
        public int CalculationOrder { get; private set; }

        protected ItemTax() { }

        public ItemTax(Guid taxCodeId, int calculationOrder)
        {
            TaxCodeId = taxCodeId;
            CalculationOrder = calculationOrder;
        }
    }
}

