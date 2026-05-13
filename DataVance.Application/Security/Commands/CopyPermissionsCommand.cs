using DataVance.Application.Common.Dictionary;
using DataVance.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Commands
{
    [HasPermission("EditPermissions", PermissionsDictionary.Copy)]
    public record CopyPermissionsCommand : IRequest<bool>
    {
        public Guid SourceTargetId { get; init; }
        public PermissionTarget SourceTargetType { get; init; }
        public Guid DestinationTargetId { get; init; }
        public PermissionTarget DestinationTargetType { get; init; }
    }
}

