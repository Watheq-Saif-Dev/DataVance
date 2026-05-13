using Dapper;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.FinancialReports.DTOs;
using DataVance.Application.Features.FinancialReports.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FinancialReports.Handlers
{
    public class GetTrialBalanceHandler : IRequestHandler<GetTrialBalanceQuery, List<TrialBalanceDto>>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IApplicationDbContext _context;


        public GetTrialBalanceHandler(IDbConnection dbConnection, IApplicationDbContext context)
        {
            _dbConnection = dbConnection;
            _context = context;

        }
        public async Task<List<TrialBalanceDto>> Handle(GetTrialBalanceQuery request, CancellationToken ct)
        {
            const string sql = @"
        WITH AccountStats AS (
            SELECT 
                AccountId,
                -- حساب أرصدة أول المدة (كل ما قبل تاريخ البداية)
                SUM(CASE WHEN FiscalPeriodId < @StartPeriodId THEN DebitTotal - CreditTotal ELSE 0 END) AS OpeningBalance,
                -- حساب حركات الفترة الحالية
                SUM(CASE WHEN FiscalPeriodId >= @StartPeriodId AND FiscalPeriodId <= @EndPeriodId THEN DebitTotal ELSE 0 END) AS PeriodDebit,
                SUM(CASE WHEN FiscalPeriodId >= @StartPeriodId AND FiscalPeriodId <= @EndPeriodId THEN CreditTotal ELSE 0 END) AS PeriodCredit
            FROM AccountBalances
            WHERE BranchId = @BranchId
            GROUP BY AccountId
        )
        SELECT 
            a.Code AS AccountCode,
            a.Name AS AccountName,
            CASE WHEN s.OpeningBalance > 0 THEN s.OpeningBalance ELSE 0 END AS OpeningDebit,
            CASE WHEN s.OpeningBalance < 0 THEN ABS(s.OpeningBalance) ELSE 0 END AS OpeningCredit,
            ISNULL(s.PeriodDebit, 0) AS PeriodDebit,
            ISNULL(s.PeriodCredit, 0) AS PeriodCredit
        FROM Accounts a
        LEFT JOIN AccountStats s ON a.Id = s.AccountId
        WHERE a.IsActive = 1
        ORDER BY a.Code";
            var startPeriodId = await _context.FiscalPeriods
                .Where(p => p.FiscalYearId == request.FiscalYearId && p.StartDate <= request.FromDate && p.EndDate >= request.FromDate)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();

            var endPeriodId = await _context.FiscalPeriods
                .Where(p => p.FiscalYearId == request.FiscalYearId && p.StartDate <= request.ToDate && p.EndDate >= request.ToDate)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();
            var result = await _dbConnection.QueryAsync<TrialBalanceDto>(sql, new
            {
                BranchId = request.BranchId,
                StartPeriodId = startPeriodId,
                EndPeriodId = endPeriodId
            });

            return result.ToList();
        }
    }
}



