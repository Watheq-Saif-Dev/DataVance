using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.DTO.JournalDTO
{
    public class JournalEntryDto
    {
        public Guid Id { get; set; }
        public string EntryNumber { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Guid? BranchId { get; set; }
        public Guid FiscalYearId { get; set; }
        public Guid FiscalPeriodId { get; set; }
        public Guid CurrencyId { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; }

        public List<JournalLineDto> Lines { get; set; } = new();
    }

    public class JournalLineDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal DebitTransaction { get; set; }
        public decimal CreditTransaction { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal ExchangeRate { get; set; }
        public Guid? CostCenterId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal DebitBase { get; set; }
        public decimal CreditBase { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}


