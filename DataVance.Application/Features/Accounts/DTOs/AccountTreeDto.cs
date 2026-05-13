using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.DTOs
{
    public record AccountTreeDto(
        Guid Id,
        string Code,
        string Name,
        bool AllowPosting,
        bool IsActive,
        int Type,
        string? DefaultCurrencyName,
    string? DefaultCurrencySymbol,
        List<AccountTreeDto> Children
    );
}


