using DataVance.Application.Features.FiscalYears.Commands;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.Handlers
{
    public class TogglePeriodStatusHandler : IRequestHandler<TogglePeriodStatusCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFiscalPeriodRepository _periodRepo;

        public TogglePeriodStatusHandler(IUnitOfWork unitOfWork, IFiscalPeriodRepository periodRepo)
        {
            _unitOfWork = unitOfWork;
            _periodRepo = periodRepo;
        }

        public async Task<bool> Handle(TogglePeriodStatusCommand request, CancellationToken ct)
        {
            var period = await _periodRepo.GetByIdAsync(request.PeriodId);

            if (period == null)
                throw new Exception("ÇáÝÊÑÉ ÇáãÍÇÓÈíÉ ÛíÑ ãæÌæÏÉ.");
            if (request.IsClosed)
                period.ClosePeriod();
            else
                period.OpenPeriod();
            _periodRepo.Update(period);
            var result = await _unitOfWork.SaveChangesAsync(ct);

            return result > 0;
        }
    }
}


