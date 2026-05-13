using DataVance.Application.Common;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Currencies.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Currencies.Handlers
{
    public class GetCurrencyLookupHandler : IRequestHandler<GetCurrencyLookupQuery, List<LookupItem>>
    {
        private readonly ILookUpService _lookUpService;

        public GetCurrencyLookupHandler(ILookUpService lookUpService)
        {
            _lookUpService = lookUpService;
        }
        public async Task<List<LookupItem>> Handle(GetCurrencyLookupQuery request, CancellationToken cancellationToken)
        {
            return await _lookUpService.GetCurrencyLookup(request.AccountId, request.Filter);
        }
    }
}

