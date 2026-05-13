using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.DTOs
{
    public record FiscalYearDto(
    Guid Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    bool IsClosed,
    bool IsActive
);
}

