using DataVance.Application.FinanceSystem.DTO.JournalDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Commands.JournalCommand
{
    public class CreateJournalEntryCommand : IRequest<Guid>
    {
        public string EntryNumber { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public Guid BranchId { get; set; }
        public Guid CurrencyId { get; set; }
        
        private decimal _exchangeRate = 1;
        public decimal ExchangeRate 
        { 
            get => _exchangeRate; 
            set => _exchangeRate = value != default ? value : 1; 
        }
        public string Description { get; set; } = string.Empty;
        public List<JournalLineInput> Lines { get; set; } = new();

        public CreateJournalEntryCommand(string entryNumber, DateTime date, Guid branchId, Guid currencyId, decimal rate, string desc, List<JournalLineInput> lines)
        {
            if (branchId == Guid.Empty)
                throw new ArgumentException("BranchId is mandatory", nameof(branchId));

            EntryNumber = entryNumber;
            EntryDate = date;
            BranchId = branchId;
            CurrencyId = currencyId;
            ExchangeRate = rate;
            Description = desc;
            Lines = lines;
        }
    }


}

