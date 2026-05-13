using DataVance.Application.FinanceSystem.Commands;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.Handler
{
    public class ReverseJournalEntryHandler : IRequestHandler<ReverseJournalEntryCommand, bool>
    {
        private readonly IJournalEntryRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJournalNumberGenerator _numberGenerator;

        public ReverseJournalEntryHandler(IJournalEntryRepository repo, IUnitOfWork unitOfWork, IJournalNumberGenerator numberGenerator)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _numberGenerator = numberGenerator;
        }

        public async Task<bool> Handle(ReverseJournalEntryCommand request, CancellationToken ct)
        {
            var originalEntry = await _repo.GetByIdAsync(request.JournalEntryId);
                if (originalEntry == null) throw new Exception("القيد الأصلي غير موجود.");

                var newNumber = await _numberGenerator.GenerateNextNumberAsync();
                var reversalEntry = originalEntry.CreateReversal(newNumber, request.Reason);

                await _repo.AddAsync(reversalEntry);
                await _unitOfWork.SaveChangesAsync(ct);

                return true;
        }
    }
}

