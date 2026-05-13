using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.OpeningBalances.DTOs;
using DataVance.Application.Features.OpeningBalances.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.Handlers
{
    public class GetUnpostedBalancesHandler : IRequestHandler<GetUnpostedBalancesQuery, IEnumerable<OpeningBalanceDto>>
    {
        private readonly IOpeningBalanceRepository _repo;

        public GetUnpostedBalancesHandler(IOpeningBalanceRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<OpeningBalanceDto>> Handle(GetUnpostedBalancesQuery request, CancellationToken ct)
        {
            var entities = await _repo.GetUnpostedBalancesAsync(request.BranchId, ct);

            return entities.Select(x => new OpeningBalanceDto
            {
                Id = x.Id,
                OpeningDate = x.OpeningDate,
                BranchId = x.BranchId, 
                CurrencyCode = x.CurrencyCode ?? "N/A",
                ExchangeRate = x.ExchangeRate <= 0 ? 1 : x.ExchangeRate, 
                IsPosted = x.IsPosted,
                Lines = x.Lines.Select(l => new OpeningBalanceLineDto
                {
                    AccountId = l.AccountId,
                    Debit = l.Debit.Amount, 
                    Credit = l.Credit.Amount
                }).ToList()
            });
        }
    }
}


