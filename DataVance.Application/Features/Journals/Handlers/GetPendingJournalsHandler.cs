using DataVance.Application.AuditSystem.DTO;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.FinanceSystem.DTO.JournalDTO;
using DataVance.Application.FinanceSystem.Query.JournalQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Handler.JournalHandler
{


    public class GetPendingJournalsHandler : IRequestHandler<GetPagedJournalsQuery, PaginatedList<JournalReviewDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPendingJournalsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<JournalReviewDto>> Handle(GetPagedJournalsQuery request, CancellationToken ct)
        {
            var query = _context.JournalEntries
             .Where(x => x.BranchId == request.BranchId)
             .AsNoTracking();

            if (request.Status.HasValue)
            {
                query = query.Where(x => x.Status == request.Status.Value);
            }
            var count = await query.CountAsync(ct);

            var items = await query
            .OrderByDescending(x => x.EntryDate)
            .Skip(request.PageNumber * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new JournalReviewDto
            {
                Id = x.Id,
                EntryNumber = x.EntryNumber,
                EntryDate = x.EntryDate,
                Description = x.Description,
                Status = x.Status,
                TotalDebitLocal = x.Lines.Sum(l => l.BaseDebit.Amount),
                TotalCreditLocal = x.Lines.Sum(l => l.BaseCredit.Amount)
            })
            .ToListAsync(ct);

            return new PaginatedList<JournalReviewDto>(items, count, request.PageNumber, request.PageSize);
        }
    }
}


