using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.DTOs
{
    public record ExchangeRateHistoryDto(
        Guid Id,
        decimal Rate,
        DateTime EffectiveDate
    );
}


