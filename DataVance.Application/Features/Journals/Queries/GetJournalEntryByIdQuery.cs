using DataVance.Application.FinanceSystem.DTO.JournalDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Query.JournalQuery
{
    public record GetJournalEntryByIdQuery(Guid Id) : IRequest<JournalEntryDto>;
}
