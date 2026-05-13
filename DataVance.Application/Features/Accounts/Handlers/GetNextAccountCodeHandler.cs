using Dapper;
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
    public class GetNextAccountCodeHandler : IRequestHandler<GetNextAccountCodeQuery, string>
    {
        private readonly IDbConnection _db;
        public GetNextAccountCodeHandler(IDbConnection db) => _db = db;

        public async Task<string> Handle(GetNextAccountCodeQuery request, CancellationToken ct)
        {
            string sql;
            string nextCode;

            if (request.ParentId == null || request.ParentId == Guid.Empty)
            {
                sql = "SELECT MAX(Code) FROM Accounts WHERE ParentId IS NULL";
                var maxCode = await _db.ExecuteScalarAsync<string>(sql);

                if (string.IsNullOrEmpty(maxCode)) return "1";

                if (int.TryParse(maxCode, out int lastNum))
                    return (lastNum + 1).ToString();

                return maxCode + "1";
            }
            else
            {
                var parentCode = await _db.ExecuteScalarAsync<string>(
                    "SELECT Code FROM Accounts WHERE Id = @Id", new { Id = request.ParentId });
                sql = "SELECT MAX(Code) FROM Accounts WHERE ParentId = @Id";
                var lastChildCode = await _db.ExecuteScalarAsync<string>(sql, new { Id = request.ParentId });

                if (string.IsNullOrEmpty(lastChildCode))
                {
                    return parentCode + "01";
                }
                string prefix = lastChildCode.Substring(0, lastChildCode.Length - 2);
                string suffix = lastChildCode.Substring(lastChildCode.Length - 2);

                if (int.TryParse(suffix, out int lastChildNum))
                {
                    return prefix + (lastChildNum + 1).ToString("D2");
                }

                return lastChildCode + "01";
            }
        }
    }
}



