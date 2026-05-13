using DataVance.Application.Common;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Currencies.Queries;
using DataVance.Application.Features.Warehouses.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Handlers
{
    public class GetCurrencyLookupHandler : IRequestHandler<GetWarehousesLookupQuery, List<LookupItem>>
    {
        private readonly ILookUpService _lookUpService;
        private readonly ICurrentUserContext _currentUser;

        public GetCurrencyLookupHandler(ILookUpService lookUpService, ICurrentUserContext currentUser)
        {
            _lookUpService = lookUpService;
            _currentUser = currentUser;
        }
        public async Task<List<LookupItem>> Handle(GetWarehousesLookupQuery request, CancellationToken cancellationToken)
        {
            return await _lookUpService.GetWarehousesLookup(_currentUser.UserId);
        }
    }
}
