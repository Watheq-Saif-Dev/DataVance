using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.Commands
{
    public record CloseFiscalYearCommand(
        Guid BranchId,
        Guid FiscalYearId,
        Guid RetainedEarningsAccountId,
        string Description
    ) : IRequest<Guid>;
}


