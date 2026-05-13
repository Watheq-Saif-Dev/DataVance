using Dapper;
using DataVance.Application.Features.FinancialReports.DTOs;
using DataVance.Application.Features.FinancialReports.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVance.Application.Features.Accounts.DTOs;

namespace DataVance.Application.Features.FinancialReports.Handlers
{



    public class GetFinancialDashboardHandler : IRequestHandler<GetFinancialDashboardQuery, FinancialDashboardDto>
    {
        private readonly IDbConnection _db;
        public GetFinancialDashboardHandler(IDbConnection db) => _db = db;

        public async Task<FinancialDashboardDto> Handle(GetFinancialDashboardQuery request, CancellationToken ct)
        {
            const string sql = @"
            -- 1. ط§ظ„ظ…ط¤ط´ط±ط§طھ (ط§ظ„ط£طµظˆظ„ ط§ظ„ظ…طھط¯ط§ظˆظ„ط© - ط§ظ„ظ…طµط±ظˆظپط§طھ - طµط§ظپظٹ ط§ظ„ط±ط¨ط­)
            SELECT 
                ISNULL((SELECT SUM(DebitTotal - CreditTotal) FROM  AccountBalances b 
                        JOIN  Accounts a ON b.AccountId = a.Id WHERE a.Type = 1), 0) as TotalLiquidity,
                ISNULL((SELECT SUM(DebitTotal - CreditTotal) FROM  AccountBalances b 
                        JOIN  Accounts a ON b.AccountId = a.Id WHERE a.Type = 5 AND b.FiscalPeriodId = @PeriodId), 0) as TotalExpenses,
                ISNULL((SELECT SUM(CreditTotal - DebitTotal) FROM  AccountBalances b 
                        JOIN  Accounts a ON b.AccountId = a.Id WHERE a.Type = 4), 0) - 
                ISNULL((SELECT SUM(DebitTotal - CreditTotal) FROM  AccountBalances b 
                        JOIN  Accounts a ON b.AccountId = a.Id WHERE a.Type = 5), 0) as NetProfit;

            -- 2. ط§ظ„ط±ط³ظ… ط§ظ„ط¨ظٹط§ظ†ظٹ (ط¯ظ…ط¬ ط±ظ‚ظ… ط§ظ„ط´ظ‡ط± ظ…ط¹ ط§ط³ظ… ط§ظپطھط±ط§ط¶ظٹ)
            SELECT CAST(MonthNumber AS VARCHAR) as MonthName, 
                   ISNULL((SELECT SUM(CreditTotal - DebitTotal) FROM  AccountBalances WHERE FiscalPeriodId = p.Id AND AccountId IN (SELECT Id FROM  Accounts WHERE Type = 4)), 0) as Revenues,
                   ISNULL((SELECT SUM(DebitTotal - CreditTotal) FROM  AccountBalances WHERE FiscalPeriodId = p.Id AND AccountId IN (SELECT Id FROM  Accounts WHERE Type = 5)), 0) as Expenses
            FROM  FiscalPeriods p ORDER BY p.StartDate;

            -- 3. ط£ط¹ظ„ظ‰ 5 ط­ط³ط§ط¨ط§طھ طµط±ظپ (ط¨ط§ط³طھط®ط¯ط§ظ… ط§ط³ظ… ط§ظ„ط­ط³ط§ط¨ ط§ظ„ط­ظ‚ظٹظ‚ظٹ)
            SELECT TOP 5 a.Name as AccountName, SUM(b.DebitTotal - b.CreditTotal) as Amount
            FROM  AccountBalances b
            JOIN  Accounts a ON b.AccountId = a.Id
            WHERE a.Type = 5 AND b.FiscalPeriodId = @PeriodId
            GROUP BY a.Name ORDER BY Amount DESC;";

            using var multi = await _db.QueryMultipleAsync(sql, new { PeriodId = request.CurrentPeriodId });

            var kpis = await multi.ReadFirstAsync();
            var chart = (await multi.ReadAsync<MonthlyPerformanceDto>()).ToList();
            var topExp = (await multi.ReadAsync<TopAccountDto>()).ToList();

            return new FinancialDashboardDto(
                Convert.ToDecimal(kpis.TotalLiquidity),
                Convert.ToDecimal(kpis.TotalExpenses),
                Convert.ToDecimal(kpis.NetProfit),
                chart,
                topExp);
        }
    }
}


