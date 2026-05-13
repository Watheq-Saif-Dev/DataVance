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
    public class GetAccountsTreeHandler : IRequestHandler<GetAccountsTreeQuery, List<AccountTreeDto>>
    {
        private readonly IDbConnection _db;
        public GetAccountsTreeHandler(IDbConnection db) => _db = db;

        public async Task<List<AccountTreeDto>> Handle(GetAccountsTreeQuery request, CancellationToken ct)
        {

            const string sql = @"
            SELECT a.Id, a.Code, a.Name, a.AllowPosting, a.IsActive, a.ParentId, a.Type,
                   c.Name as DefaultCurrencyName, 
                   c.Symbol as DefaultCurrencySymbol
            FROM Accounts a
            LEFT JOIN Currencies c ON a.DefaultCurrencyId = c.Id
            ORDER BY a.Code";

            var flatList = (await _db.QueryAsync<AccountFlatModel>(sql)).ToList();
            return BuildTree(flatList, null);
        }

        private List<AccountTreeDto> BuildTree(List<AccountFlatModel> flatList, Guid? parentId)
        {
            return flatList
             .Where(x => x.ParentId == parentId)
             .Select(x => new AccountTreeDto(
                 x.Id,
                 x.Code,
                 x.Name,
                 x.AllowPosting,
                 x.IsActive,
                 x.Type,
                 x.DefaultCurrencyName,
                 x.DefaultCurrencySymbol,
                 BuildTree(flatList, x.Id)
             )).ToList();
        }
    }
    internal record AccountFlatModel(
       Guid Id,
       string Code,
       string Name,
       bool AllowPosting,
       bool IsActive,
       Guid? ParentId,
       int Type,
       string? DefaultCurrencyName,
       string? DefaultCurrencySymbol
   );
}



