using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.DTO.JournalDTO
{
    public class JournalLineInput
    {
        public Guid AccountId { get; set; }
        private decimal _debit;
        public decimal Debit { 
            get => _debit; 
            set => _debit = value != default ? value : 0; 
        }

        private decimal _credit;
        public decimal Credit { 
            get => _credit; 
            set => _credit = value != default ? value : 0; 
        }

        public string Description { get; set; } = string.Empty;
        public Guid? CostCenterId { get; set; }
        public Guid? CurrencyId { get; set; }
        
        private decimal _exchangeRate = 1;
        public decimal? ExchangeRate { 
            get => _exchangeRate; 
            set => _exchangeRate = value ?? 1; 
        }

        public JournalLineInput(Guid accountId, decimal debit, decimal credit, string desc)
        {
            AccountId = accountId;
            Debit = debit;
            Credit = credit;
            Description = desc;
        }
    }
}

