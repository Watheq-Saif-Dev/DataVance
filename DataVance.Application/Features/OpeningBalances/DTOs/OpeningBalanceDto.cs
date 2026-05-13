using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.DTOs
{


    public class OpeningBalanceDto
    {
        public Guid Id { get; set; }

        public DateTime OpeningDate { get; set; } = DateTime.Today;
        public Guid BranchId { get; set; }
        public Guid CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = "YER";
        public decimal ExchangeRate { get; set; } = 1;
        public bool IsPosted { get; set; }

        public List<OpeningBalanceLineDto> Lines { get; set; } = new();
        public decimal TotalDebit => Lines.Sum(l => l.Debit);
        public decimal TotalCredit => Lines.Sum(l => l.Credit);
        public decimal Difference => Math.Abs(TotalDebit - TotalCredit);
        public bool IsBalanced => Difference <= 0.001m;
    }
}



