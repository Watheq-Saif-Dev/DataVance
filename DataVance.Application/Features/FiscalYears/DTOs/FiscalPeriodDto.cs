using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.DTOs
{
    public record FiscalPeriodDto(
         Guid Id,
         Guid FiscalYearId,
         int MonthNumber,
         string Name,
         DateTime StartDate,
         DateTime EndDate,
         bool IsClosed,
         bool IsClosingPeriod
     );
}


