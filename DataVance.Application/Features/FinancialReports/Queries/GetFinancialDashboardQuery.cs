using DataVance.Application.Features.FinancialReports.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FinancialReports.Queries
{
    public record GetFinancialDashboardQuery(Guid CurrentPeriodId) : IRequest<FinancialDashboardDto>;
}

