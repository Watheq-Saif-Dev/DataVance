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
    public class GetCurrenciesHandler : IRequestHandler<GetCurrenciesQuery, List<CurrencyDto>>
    {
        private readonly IDbConnection _db;
        public GetCurrenciesHandler(IDbConnection db) => _db = db;

        public async Task<List<CurrencyDto>> Handle(GetCurrenciesQuery request, CancellationToken ct)
        {
            var sql = @"
        SELECT 
            Id, 
            Name, 
            Code, 
            Symbol, 
            DecimalPlaces, 
            IsBaseCurrency, 
            CurrentExchangeRate, 
            IsActive 
        FROM Currencies 
        ORDER BY IsBaseCurrency DESC, Name ASC";

            var result = await _db.QueryAsync<CurrencyDto>(sql);
            return result.ToList();
        }
    }
}


