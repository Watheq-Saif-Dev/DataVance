using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Commands;
using DataVance.Application.Security.Service;
using DataVance.Domain.Entities.SecuritySystem;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler.Permissions
{
    public class CopyPermissionsHandler : IRequestHandler<CopyPermissionsCommand, bool>
    {
        private readonly IPermissionService _permission;

        public CopyPermissionsHandler(IPermissionService permission) => _permission = permission;

        public async Task<bool> Handle(CopyPermissionsCommand request, CancellationToken ct)
        {

            var sourcePermissions = await _permission.GetPerJustByTargetAsync(request.SourceTargetId, request.SourceTargetType);

            if (!sourcePermissions.Any()) return false;
            var destinationOldPermissions = await _permission.GetPerJustByTargetAsync(request.DestinationTargetId, request.DestinationTargetType);

            await _permission.RemoveRangeAsync(destinationOldPermissions);

            var clonedPermissions = sourcePermissions.Select(p => Permission.Create(
                                                          request.DestinationTargetId,
                                                          request.DestinationTargetType,
                                                          p.PageId,
                                                          p.ActionId,
                                                          p.ActionCode
                                                      )).ToList();
            foreach (var p in clonedPermissions)
            {
                await _permission.AddAsync(p);
            }


            return true;
        }
    }
}

