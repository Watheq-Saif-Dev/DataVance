using MediatR;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Rules.Events;
using DataVance.Application.Features.FiscalYears.Commands;
using System.Threading;
using DataVance.Domain.Common;

namespace DataVance.Application.Features.FiscalYears.Handlers
{
    public class CloseFiscalPeriodHandler : IRequestHandler<CloseFiscalPeriodCommand, bool>
    {
        private readonly IFiscalPeriodRepository _periodRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CloseFiscalPeriodHandler(
            IFiscalPeriodRepository periodRepo,
            IUnitOfWork unitOfWork)
        {
            _periodRepo = periodRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CloseFiscalPeriodCommand request, CancellationToken ct)
        {
            var period = await _periodRepo.GetByIdAsync(request.FiscalPeriodId);

            if (period == null)
                throw new Exception("Fiscal Period not found.");

            if (period.IsClosed)
                throw new InvalidOperationException("Fiscal Period is already closed.");

            period.AddDomainEvent(new PostToAccountingEvent(
                ReferenceId: period.Id, // أو FiscalYearId حسب تصميم العملية
                OperationCode: "ACC_CLOSE",
                EventDate: DateTime.UtcNow,
                BranchId: request.BranchId
            ));

            await _unitOfWork.SaveChangesAsync(ct);

            return true;
        }
    }
}
