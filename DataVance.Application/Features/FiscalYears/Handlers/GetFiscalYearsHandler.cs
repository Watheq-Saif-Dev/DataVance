using Dapper;
using DataVance.Application.Features.FiscalYears.DTOs;
using DataVance.Application.Features.FiscalYears.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.Handlers
{
    public class GetFiscalYearsHandler : IRequestHandler<GetFiscalYearsQuery, List<FiscalYearDto>>
    {
        private readonly IDbConnection _db;

        public GetFiscalYearsHandler(IDbConnection db)
        {
            _db = db;
        }

        public async Task<List<FiscalYearDto>> Handle(GetFiscalYearsQuery request, CancellationToken ct)
        {
            const string sql = @"
            SELECT Id, Name, StartDate, EndDate, IsClosed, IsActive
            FROM FiscalYears
            ORDER BY StartDate DESC";

            var result = await _db.QueryAsync<FiscalYearDto>(sql);

            return result.ToList();
        }
    }
}


