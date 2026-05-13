using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.DTOs
{
    public record CurrencyDto(
         Guid Id,
         string Name,
         string Code,
         string Symbol,
         int DecimalPlaces,
         bool IsBaseCurrency,
         decimal CurrentExchangeRate,
         bool IsActive
     );
}

