using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.OpeningBalances.Commands;
using DataVance.Domain.Common;
using DataVance.Domain.Common.Models;
using DataVance.Domain.Finance.Journal.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.Handlers
{
    public class PostAllOpeningBalancesHandler : IRequestHandler<PostAllOpeningBalancesCommand, Result>
    {
        private readonly IOpeningBalanceRepository _openingRepo;
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IUnitOfWork _uow;
        private readonly ICurrentUserContext _currentUser;

        public async Task<Result> Handle(PostAllOpeningBalancesCommand request, CancellationToken ct)
        {
            var allPendingBalances = await _openingRepo.GetUnpostedBalancesAsync(request.BranchId, ct);
            if (!allPendingBalances.Any()) return Result.Failure("ظ„ط§ طھظˆط¬ط¯ ط£ط±طµط¯ط© ط§ظپطھطھط§ط­ظٹط© ط¨ط§ظ†طھط¸ط§ط± ط§ظ„طھط±ط­ظٹظ„.");
                var firstDoc = allPendingBalances.First();
                var journalEntry = new JournalEntry(
                    "OB-TOTAL-" + DateTime.Now.ToString("yyyyMMdd"),
                    DateTime.UtcNow,
                    firstDoc.BranchId,
                    request.FiscalYearId,
                    request.FiscalPeriodId,
                    firstDoc.CurrencyId,
                    firstDoc.CurrencyCode,
                    firstDoc.ExchangeRate
                );

                journalEntry.UpdateDescription("ظ‚ظٹط¯ ط§ظ„ط£ط±طµط¯ط© ط§ظ„ط§ظپطھطھط§ط­ظٹط© ط§ظ„ظ…ط¬ظ…ط¹ ظ„ظƒط§ظپط© ط§ظ„ط­ط³ط§ط¨ط§طھ");
                foreach (var doc in allPendingBalances)
                {
                    foreach (var line in doc.Lines)
                    {
                        journalEntry.AddLine(
                            line.AccountId,
                            line.Debit.Amount,
                            line.Credit.Amount,
                            null,
                            doc.CurrencyId,
                            doc.ExchangeRate);
                    }
                    doc.MarkAsPosted(journalEntry.Id);
                }
                journalEntry.ValidateBalance();
                journalEntry.Post(isSystemGenerated: true);
                await _journalRepo.AddAsync(journalEntry);
            await _uow.SaveChangesAsync(ct);

            return Result.Success();
        }
    }
}



