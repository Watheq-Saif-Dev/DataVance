using DataVance.Application.FinanceSystem.Commands.JournalCommand;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Handler.JournalHandler
{
    public class ApproveJournalEntryHandler : IRequestHandler<ApproveJournalEntryCommand, bool>
    {
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ApproveJournalEntryHandler(IJournalEntryRepository journalRepo, IUnitOfWork unitOfWork)
        {
            _journalRepo = journalRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ApproveJournalEntryCommand request, CancellationToken ct)
        {
            var entry = await _journalRepo.GetByIdAsync(request.JournalEntryId);
            if (entry == null) throw new Exception("«·ﬁÌœ €Ì— „ÊÃÊœ.");
            entry.Approve();

            await _unitOfWork.SaveChangesAsync(ct);
            return true;
        }
    }
}

