using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.Commands
{
    public record UpdateCurrencyCommand(
     Guid Id,
     string Name,
     string Symbol,
     int DecimalPlaces,
     bool IsActive,
     decimal NewRate
 ) : IRequest<bool>;
}


