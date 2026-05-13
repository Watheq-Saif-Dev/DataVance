using DataVance.Application.Common.Interfaces;
using DataVance.Application.FinanceSystem.Commands.JournalCommand;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Journal.Entities;
using MediatR;
namespace DataVance.Application.FinanceSystem.Handler.JournalHandler
{

    public class CreateJournalEntryHandler : IRequestHandler<CreateJournalEntryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IFiscalPeriodRepository _periodRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrentUserContext _currentUser;

        public CreateJournalEntryHandler(
                IUnitOfWork unitOfWork,
                IJournalEntryRepository journalRepo,
                IFiscalPeriodRepository periodRepo,
                IAccountRepository accountRepo,
                ICurrencyRepository currencyRepository,
                ICurrentUserContext currentUser)
        {
            _unitOfWork = unitOfWork;
            _journalRepo = journalRepo;
            _periodRepo = periodRepo;
            _accountRepo = accountRepo;
            _currencyRepository = currencyRepository;
            _currentUser = currentUser;
        }

        public async Task<Guid> Handle(CreateJournalEntryCommand request, CancellationToken ct)
        {
            var currency = await _currencyRepository.GetByIdAsync(request.CurrencyId);
            if (currency == null) throw new Exception("العملة المحددة غير موجودة.");


            var period = await _periodRepo.GetPeriodByDateAsync(request.EntryDate);

            if (period == null)
                throw new InvalidOperationException("لا توجد فترة مالية معرفة لهذا التاريخ.");

            if (period.IsClosed)
                throw new InvalidOperationException($"الفترة المحاسبية {period.Name} مغلقة، لا يمكن إضافة قيود.");
            var entry = new JournalEntry(
                request.EntryNumber,
                request.EntryDate,
                _currentUser.BranchId,
                period.FiscalYearId,
                period.Id,
                request.CurrencyId,
                currency.Code,
                request.ExchangeRate
            );

            entry.UpdateDescription(request.Description);
            foreach (var line in request.Lines)
            {
                var account = await _accountRepo.GetByIdAsync(line.AccountId);
                if (account == null || !account.AllowPosting)
                    throw new InvalidOperationException($"الحساب المحدد {line.AccountId} غير موجود أو لا يسمح بالترحيل.");
                var lineCurrencyId = line.CurrencyId ?? request.CurrencyId;
                var lineExchangeRate = line.ExchangeRate ?? (lineCurrencyId == request.CurrencyId ? request.ExchangeRate : 1);

                entry.AddLine(
                    line.AccountId,
                    line.Debit,
                    line.Credit,
                    line.CostCenterId,
                    lineCurrencyId,
                    lineExchangeRate);
            }
            entry.ValidateBalance();
            await _journalRepo.AddAsync(entry, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return entry.Id;
        }
    }
}

