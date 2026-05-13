using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.DTO
{
    public record WarehouseDto(Guid Id, string Name, string? Location);


}
