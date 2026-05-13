using DataVance.Domain.Common;

namespace DataVance.Domain.Entities.TaxSystem
{

    public class TaxType : BaseEntity
    {
        //public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty; // مثال: VAT, WHT
        public string? Description { get; private set; }

        protected TaxType() { }


        public TaxType(string name, string? description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }

        public void UpdateDetails(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
