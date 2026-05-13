using DataVance.Application.FinanceSystem.Commands;
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
    public class PostJournalEntryHandler
      : IRequestHandler<PostJournalEntryCommand, bool>
    {
        private readonly IJournalEntryRepository _journalRepo;
        private readonly IUnitOfWork _unitOfWork;

        public PostJournalEntryHandler(IJournalEntryRepository journalRepo, IUnitOfWork unitOfWork)
        {
            _journalRepo = journalRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(
            PostJournalEntryCommand request,
            CancellationToken ct)
        {
            var entry = await _journalRepo.GetByIdAsync(request.JournalEntryId);

            if (entry is null)
                throw new KeyNotFoundException($"القيد ذو المعرف {request.JournalEntryId} غير موجود.");

            entry.Post();
                await _unitOfWork.SaveChangesAsync(ct);
                return true;
        }
    }
}

