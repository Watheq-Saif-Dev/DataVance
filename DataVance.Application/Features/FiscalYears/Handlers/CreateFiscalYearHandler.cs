
using DataVance.Application.Features.FiscalYears.Commands;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.AccountingClosing.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.Handlers
{
    public class CreateFiscalYearHandler : IRequestHandler<CreateFiscalYearCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFiscalYearRepository _fiscalYearRepo;

        public CreateFiscalYearHandler(IUnitOfWork unitOfWork, IFiscalYearRepository fiscalYearRepo)
        {
            _unitOfWork = unitOfWork;
            _fiscalYearRepo = fiscalYearRepo;
        }

        public async Task<Guid> Handle(CreateFiscalYearCommand request, CancellationToken ct)
        {
            var isOverlapping = await _fiscalYearRepo.IsOverlappingAsync(request.StartDate, request.EndDate);
            if (isOverlapping)
                throw new Exception(" «—ÌŒ «·”‰… «·„«·Ì… „ œ«Œ· „⁄ ”‰… „ÊÃÊœ… „”»ﬁ«.");
            var fiscalYear = new FiscalYear(request.Name, request.StartDate, request.EndDate);
            await _fiscalYearRepo.AddAsync(fiscalYear);
            await _unitOfWork.SaveChangesAsync(ct);

            return fiscalYear.Id;
        }
    }
}


