using DataVance.Application.Features.OpeningBalances.DTOs;
using DataVance.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.Queries
{
    public record GetUnpostedBalancesQuery : IRequest<IEnumerable<OpeningBalanceDto>>
    {
        public required Guid BranchId { get; init; }
    }
}
