using DataVance.Application.Common;
using DataVance.Application.Features.Currencies.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.Queries
{
    public record GetCurrenciesQuery : IRequest<List<CurrencyDto>>;
    public record GetCurrencyLookupQuery(string? Filter, Guid? AccountId) : IRequest<List<LookupItem>>;
}


