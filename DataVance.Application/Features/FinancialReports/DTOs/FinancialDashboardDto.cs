using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVance.Application.Features.Accounts.DTOs;

namespace DataVance.Application.Features.FinancialReports.DTOs
{
    public record FinancialDashboardDto(
           decimal TotalLiquidity,
           decimal TotalExpenses,
           decimal NetProfit,
           List<MonthlyPerformanceDto> MonthlyChart,
           List<TopAccountDto> TopExpenses
       );
}

