using DataVance.Application.Features.Currencies.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.Queries
{
    public record GetExchangeRateHistoryQuery(Guid CurrencyId) : IRequest<List<ExchangeRateHistoryDto>>;
}

