using DataVance.Application.Common.Dictionary;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.Security.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Commands
{
    [HasPermission("TestWarehouse", PermissionsDictionary.Create)]
    public record CreateWarehouseCommand : IRequest<Guid>
    {

        public string Name { get; init; } = "";
        public string Location { get; init; } = "";
    }
}
