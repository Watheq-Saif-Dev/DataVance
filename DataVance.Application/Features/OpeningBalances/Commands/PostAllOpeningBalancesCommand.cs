using DataVance.Domain.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.Commands
{
    public record PostAllOpeningBalancesCommand : IRequest<Result>
    {
        public Guid FiscalYearId { get; init; }
        public Guid FiscalPeriodId { get; init; }
        public required Guid BranchId { get; init; }
    }
}

