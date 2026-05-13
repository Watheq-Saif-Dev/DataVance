using DataVance.Application.AuditSystem.DTO;
using DataVance.Application.FinanceSystem.DTO.JournalDTO;
using DataVance.Domain.Finance.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Query.JournalQuery
{
    public record GetPagedJournalsQuery : IRequest<PaginatedList<JournalReviewDto>>
    {
        public int PageNumber { get; init; } = 0;
        public int PageSize { get; init; } = 10;
        public JournalStatus? Status { get; init; }
        public Guid? BranchId { get; init; }
    }
}

