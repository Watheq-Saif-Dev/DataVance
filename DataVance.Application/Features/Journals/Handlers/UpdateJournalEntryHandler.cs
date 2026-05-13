using DataVance.Application.Common.Interfaces;
using DataVance.Application.FinanceSystem.Commands.JournalCommand;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Handler.JournalHandler
{
    public class UpdateJournalEntryHandler : IRequestHandler<UpdateJournalEntryCommand, Guid>
    {
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserContext _currentUser;

        public UpdateJournalEntryHandler(
            IJournalEntryRepository journalRepo,
            IUnitOfWork unitOfWork,
            ICurrentUserContext currentUser)
        {
            _journalRepo = journalRepo;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Guid> Handle(UpdateJournalEntryCommand request, CancellationToken ct)
        {
            if (_currentUser.BranchId == Guid.Empty)
                throw new InvalidOperationException("لا يمكن تعديل القيد بدون تحديد الفرع.");
            var entry = await _journalRepo.GetByIdWithLinesAsync(request.Id);

                if (entry == null)
                    throw new KeyNotFoundException($"القيد ذو المعرف {request.Id} غير موجود.");

                if (!entry.CanEdit())
                    throw new InvalidOperationException("لا يمكن تعديل القيد إلا في حالة المسودة.");
                if (entry.BranchId != _currentUser.BranchId)
                    throw new InvalidOperationException("لا يمكن تعديل قيد لا ينتمي للفرع الحالي.");
                entry.UpdateHeader(
                    request.EntryDate,
                    request.Description,
                    request.CurrencyId,
                    request.ExchangeRate);
                entry.ClearLines();

                foreach (var line in request.Lines)
                {
                    entry.AddLine(
                        line.AccountId,
                        line.Debit,
                        line.Credit,
                        line.CostCenterId,
                        request.CurrencyId,
                        request.ExchangeRate);
                }
                entry.ValidateBalance();

                await _unitOfWork.SaveChangesAsync(ct);

                return entry.Id;
        }
    }
}

