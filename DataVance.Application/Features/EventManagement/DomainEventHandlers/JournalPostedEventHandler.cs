using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Events;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Journal.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.EventManagement.EventHandler.CurrencyEvent
{
    public class JournalPostedEventHandler : INotificationHandler<DomainEventNotification<JournalPostedEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IAccountBalanceRepository _balanceRepo;
        private readonly ICurrentUserContext _currentUser;

        public JournalPostedEventHandler(
            IUnitOfWork unitOfWork,
            IJournalEntryRepository journalRepo,
            IAccountBalanceRepository balanceRepo,
            ICurrentUserContext currentUser)
        {
            _unitOfWork = unitOfWork;
            _journalRepo = journalRepo;
            _balanceRepo = balanceRepo;
            _currentUser = currentUser;
        }
        public async Task Handle(DomainEventNotification<JournalPostedEvent> notification, CancellationToken ct)
        {
            var entry = await _journalRepo.GetByIdWithLinesAsync(notification.DomainEvent.JournalEntryId);
            if (entry == null) return;
            var groupedLines = entry.Lines
                .GroupBy(l => new { l.AccountId, CurrencyId = l.TransactionDebit.CurrencyId })
                .Select(g => new
                {
                    g.Key.AccountId,
                    g.Key.CurrencyId,
                    BaseCurrencyId = g.First().BaseDebit.CurrencyId,
                    TotalDebit = g.Sum(x => x.TransactionDebit.Amount),
                    TotalCredit = g.Sum(x => x.TransactionCredit.Amount),
                    TotalLocalDebit = g.Sum(x => x.BaseDebit.Amount),
                    TotalLocalCredit = g.Sum(x => x.BaseCredit.Amount)
                });

            foreach (var group in groupedLines)
            {
                var branchId = entry.BranchId;

                var balance = await _balanceRepo.GetBalanceAsync(
                    group.AccountId,
                    branchId,
                    entry.FiscalPeriodId,
                    group.CurrencyId);

                if (balance == null)
                {
                    balance = new AccountBalance(
                        group.AccountId,
                        branchId,
                        entry.FiscalPeriodId,
                        group.CurrencyId,
                        group.BaseCurrencyId);

                    await _balanceRepo.AddAsync(balance);
                }
                if (group.TotalDebit > 0 || group.TotalLocalDebit > 0)
                {
                    balance.UpdateBalance(new DataVance.Domain.Common.Models.Money(group.TotalDebit, group.CurrencyId), new DataVance.Domain.Common.Models.Money(group.TotalLocalDebit, group.BaseCurrencyId), true);
                }

                if (group.TotalCredit > 0 || group.TotalLocalCredit > 0)
                {
                    balance.UpdateBalance(new DataVance.Domain.Common.Models.Money(group.TotalCredit, group.CurrencyId), new DataVance.Domain.Common.Models.Money(group.TotalLocalCredit, group.BaseCurrencyId), false);
                }
            }
            await _unitOfWork.SaveChangesAsync(ct);
        }
    }
}



