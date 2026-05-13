using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.Commands
{
    public record UpdateExchangeRateCommand(
         Guid CurrencyId,
         decimal NewRate,
         DateTime EffectiveDate
     ) : IRequest<bool>;
}


