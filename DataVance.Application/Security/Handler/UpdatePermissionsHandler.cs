using DataVance.Application.AuditSystem.Service;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Commands;
using DataVance.Application.Security.Service;
using DataVance.Domain.Entities.AuditSystem;
using DataVance.Domain.Entities.SecuritySystem;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler
{
    public class UpdatePermissionsHandler : IRequestHandler<UpdatePermissionsCommand, bool>
    {

        private readonly IPermissionService _permissionService;

        public UpdatePermissionsHandler(IPermissionService permissionService)
        {

            _permissionService = permissionService;
        }
        public async Task<bool> Handle(UpdatePermissionsCommand request, CancellationToken cancellationToken)
        {
            var existingPermissions = await _permissionService.GetByTargetAsync(request.TargetId, request.TargetType);


            foreach (var item in request.Permissions)
            {
                var permission = existingPermissions.FirstOrDefault(p =>
                    p.PageId == item.PageId && p.ActionId == item.ActionId);

                if (permission != null)
                {

                    permission.ToggleStatus(item.IsGranted);
                }
                else if (item.IsGranted)
                {
                    var newPermission = Permission.Create(
                        request.TargetId,
                        request.TargetType,
                        item.PageId,
                        item.ActionId,
                        item.ActionCode);

                    await _permissionService.AddAsync(newPermission);
                }
            }
            return true;

        }

    }
}

