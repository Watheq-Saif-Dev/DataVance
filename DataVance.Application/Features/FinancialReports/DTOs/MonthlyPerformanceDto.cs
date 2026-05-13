using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FinancialReports.DTOs
{
    public record MonthlyPerformanceDto(string MonthName, decimal Revenues, decimal Expenses);
}

