using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Commands.JournalCommand
{
    public record DeleteJournalEntryCommand(Guid JournalEntryId) : IRequest<bool>;
}
