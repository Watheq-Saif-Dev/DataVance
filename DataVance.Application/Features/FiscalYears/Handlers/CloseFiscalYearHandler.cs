using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Rules.Events;
using DataVance.Application.Features.FiscalYears.Commands;
using System.Threading;

namespace DataVance.Application.Features.FiscalYears.Handlers
{
    public class CloseFiscalYearHandler : IRequestHandler<CloseFiscalYearCommand, Guid>
    {
        private readonly IFiscalYearRepository _yearRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CloseFiscalYearHandler(
            IFiscalYearRepository yearRepo, 
            IUnitOfWork unitOfWork)
        {
            _yearRepo = yearRepo;
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CloseFiscalYearCommand request, CancellationToken ct)
        {
            var fiscalYear = await _yearRepo.GetByIdAsync(request.FiscalYearId);

            if (fiscalYear == null)
                throw new Exception("Fiscal Year not found.");

            if (fiscalYear.IsClosed)
                throw new InvalidOperationException("Fiscal Year is already closed.");


            // إطلاق الحدث للمحرك لكي يتعامل مع عملية الإغلاق آلياً
            fiscalYear.AddDomainEvent(new PostToAccountingEvent(
                ReferenceId: fiscalYear.Id,
                OperationCode: "ACC_CLOSE",
                EventDate: DateTime.UtcNow,
                BranchId: request.BranchId
            ));

            await _unitOfWork.SaveChangesAsync(ct);

            return fiscalYear.Id;
        }
    }
}
