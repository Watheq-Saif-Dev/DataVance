using DataVance.Application.DTOs;
using DataVance.Application.Security.DTO;
using DataVance.Domain.Entities.Enums;
using DataVance.Domain.Entities.SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Service
{
    public interface IPermissionService
    {
        Task<bool> CheckPermission(Guid userId, string pageName, string actionCode);
        Task<bool> CheckEventPermission(Guid userId, string eventCode, decimal? amount = null);
        Task<List<Permission>> GetByTargetAsync(Guid targetId, PermissionTarget targetType);
        Task AddAsync(Permission permission);
        Task<List<Permission>> GetPerJustByTargetAsync(Guid targetId, PermissionTarget targetType);
        Task UpdateAsync(Permission permission);
        Task RemoveRangeAsync(List<Permission> permissions);


        Task<List<SystemActionDto>> GutPageActionWithActivation(Guid PageId, CancellationToken ct);
        Task RemovePageActionAsync(Guid pageActionId, Guid pageId, CancellationToken ct);
        Task AddPageActionAsync(PageAction pageAction);


    }

}

