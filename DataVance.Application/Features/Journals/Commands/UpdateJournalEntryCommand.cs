using DataVance.Application.FinanceSystem.DTO.JournalDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Commands.JournalCommand
{
    public class UpdateJournalEntryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid CurrencyId { get; set; }
        public decimal ExchangeRate { get; set; }
        public List<JournalLineInput> Lines { get; set; } = new();
    }
}

