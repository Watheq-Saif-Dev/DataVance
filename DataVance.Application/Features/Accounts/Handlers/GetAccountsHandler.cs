using Dapper;
using DataVance.Application.Features.Accounts.DTOs;
using DataVance.Application.Features.Accounts.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Handlers
{

    public class GetAccountsHandler : IRequestHandler<GetAccountsQuery, List<AccountDto>>
    {
        private readonly IDbConnection _db;
        public GetAccountsHandler(IDbConnection db) => _db = db;

        public async Task<List<AccountDto>> Handle(GetAccountsQuery request, CancellationToken ct)
        {
            const string sql = @"SELECT Id, Code, Name, Type 
                     FROM Accounts 
                     WHERE IsActive = 1 AND AllowPosting = 1 
                     ORDER BY Code";
            var result = await _db.QueryAsync<AccountDto>(sql);
            return result.ToList();
        }
    }
}


