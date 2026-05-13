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

    public class UnapproveJournalEntryHandler : IRequestHandler<UnapproveJournalEntryCommand, bool>
    {
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UnapproveJournalEntryHandler(IJournalEntryRepository journalRepo, IUnitOfWork unitOfWork)
        {
            _journalRepo = journalRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UnapproveJournalEntryCommand request, CancellationToken ct)
        {
            var entry = await _journalRepo.GetByIdAsync(request.JournalEntryId);
            if (entry == null) throw new Exception("«·ﬁÌœ €Ì— „ÊÃÊœ.");


            if (entry.Status == JournalStatus.Posted)
                throw new InvalidOperationException("·« Ì„ﬂ‰ ›ﬂ «⁄ „«œ ﬁÌœ  „  —ÕÌ·Â ‰Â«∆Ì«.");

            entry.Unapprove();

            await _unitOfWork.SaveChangesAsync(ct);
            return true;
        }
    }
}
