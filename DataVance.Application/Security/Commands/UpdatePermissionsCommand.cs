using DataVance.Application.Common.Dictionary;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.DTO;
using DataVance.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Commands
{

    public record UpdatePermissionsCommand : IRequest<bool>
    {
        public Guid TargetId { get; init; }
        public PermissionTarget TargetType { get; init; }
        public List<PermissionDto> Permissions { get; init; } = new();
    }
}

