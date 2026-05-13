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

    public class GetJournalEntryByIdHandler : IRequestHandler<GetJournalEntryByIdQuery, JournalEntryDto>
    {
        private readonly IApplicationDbContext _context;
        public GetJournalEntryByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<JournalEntryDto?> Handle(GetJournalEntryByIdQuery request, CancellationToken ct)
        {
            var entry = await _context.JournalEntries
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new JournalEntryDto
                {
                    Id = x.Id,
                    EntryNumber = x.EntryNumber,
                    EntryDate = x.EntryDate,
                    Description = x.Description,
                    Status = x.Status.ToString(),
                    BranchId = x.BranchId,
                    FiscalYearId = x.FiscalYearId,
                    FiscalPeriodId = x.FiscalPeriodId,
                    CurrencyId = x.CurrencyId,
                    CurrencyCode = x.CurrencyCode,
                    ExchangeRate = x.ExchangeRate,
                    Lines = x.Lines.Select(l => new JournalLineDto
                    {
                        Id = l.Id,
                        AccountId = l.AccountId,
                        DebitTransaction = l.TransactionDebit.Amount,
                        CreditTransaction = l.TransactionCredit.Amount,
                        CurrencyId = l.TransactionDebit.CurrencyId,
                        ExchangeRate = l.ExchangeRate,
                        CostCenterId = l.CostCenterId,
                        AccountName = _context.Accounts.Where(a => a.Id == l.AccountId).Select(a => a.Name).FirstOrDefault() ?? "حساب غير معروف",
                        DebitBase = l.BaseDebit.Amount,
                        CreditBase = l.BaseCredit.Amount,
                        Description = ""
                    }).ToList()
                })
                .FirstOrDefaultAsync(ct);

            return entry;
        }
    }
}


