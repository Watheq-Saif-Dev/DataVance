using Dapper;
using DataVance.Application.Features.Currencies.DTOs;
using DataVance.Application.Features.Currencies.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.Handlers
{
    public class GetExchangeRateHistoryHandler : IRequestHandler<GetExchangeRateHistoryQuery, List<ExchangeRateHistoryDto>>
    {
        private readonly IDbConnection _db;
        public GetExchangeRateHistoryHandler(IDbConnection db) => _db = db;

        public async Task<List<ExchangeRateHistoryDto>> Handle(GetExchangeRateHistoryQuery request, CancellationToken ct)
        {

            var sql = @"SELECT Id, Rate, EffectiveDate 
                    FROM ExchangeRates 
                    WHERE CurrencyId = @CurrencyId 
                    ORDER BY EffectiveDate DESC";

            var result = await _db.QueryAsync<ExchangeRateHistoryDto>(sql, new { CurrencyId = request.CurrencyId });
            return result.ToList();
        }
    }
}

