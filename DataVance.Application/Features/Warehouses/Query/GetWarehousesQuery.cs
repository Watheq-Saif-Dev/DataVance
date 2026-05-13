using DataVance.Application.Common;
using DataVance.Application.Features.Warehouses.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Query
{
    public record GetWarehousesQuery : IRequest<List<WarehouseDto>>;
    public record GetWarehousesLookupQuery : IRequest<List<LookupItem>>;

}
