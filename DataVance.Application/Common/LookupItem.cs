using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common
{
    public class LookupItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public decimal Price { get; set; } = 0;
        public int AvailableQty { get; set; } = 0;

        public decimal ExchangeRate { get; set; } = 1;
        public Guid? CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal TaxPercentage { get; set; } = 0;
        public bool IsTaxable { get; set; } = true;
        public Dictionary<string, string>? ExtraData { get; set; }
        public bool IsActive { get; set; } = true;
    }
}


