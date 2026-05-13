using DataVance.Domain.Common;

namespace DataVance.Domain.Entities.TaxSystem
{
    //يمثل الجهة الحكومية التي تشرع وتستلم الضريبه
    public class TaxAuthority : BaseEntity
    {
        //public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string CountryCode { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        protected TaxAuthority() { }

        public TaxAuthority(string name, string countryCode, string? description = null)
        {
            Name = name;
            CountryCode = countryCode;
            Description = description;
        }
    }
}
