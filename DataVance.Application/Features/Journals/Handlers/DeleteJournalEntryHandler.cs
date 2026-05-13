using DataVance.Application.FinanceSystem.Commands.JournalCommand;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Handler.JournalHandler
{

    public class DeleteJournalEntryHandler : IRequestHandler<DeleteJournalEntryCommand, bool>
    {
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteJournalEntryHandler(IJournalEntryRepository journalRepo, IUnitOfWork unitOfWork)
        {
            _journalRepo = journalRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteJournalEntryCommand request, CancellationToken ct)
        {
            var entry = await _journalRepo.GetByIdAsync(request.JournalEntryId);
            if (entry == null) return true;
            if (entry.Status != JournalStatus.Draft)
                throw new InvalidOperationException("ÇáãÚÇííÑ ÇáãÇáíÉ ÊãäÚ ÍĞİ ÇáŞíæÏ ÇáãÚÊãÏÉ Ãæ ÇáãÑÍáÉ. íãßäß ÅáÛÇÁ ÇáÇÚÊãÇÏ ÃæáÇğ Ãæ Úãá ŞíÏ ÚßÓí.");

            await _journalRepo.DeleteAsync(entry);
            await _unitOfWork.SaveChangesAsync(ct);
            return true;
        }
    }
}


