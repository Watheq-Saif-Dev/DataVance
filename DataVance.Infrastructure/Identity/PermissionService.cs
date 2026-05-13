using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.DTO;
using DataVance.Application.Security.Service;
using DataVance.Domain.Entities.Enums;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Domain.Entities.SecuritySystem;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DataVance.Infrastructure.Identity
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly IIdentityService _identityService;
        private const string PermissionCacheKey = "UserPerms_{0}"; // {0} ستكون الـ UserId
        public PermissionService(ApplicationDbContext context, IMemoryCache cache, IIdentityService identityService)
        {
            _context = context;
            _cache = cache;
            _identityService = identityService;
        }
        public async Task<bool> CheckEventPermission(Guid userId, string eventCode, decimal? amount = null)
        {

            var userRoles = await _identityService.GetUserRolesIdsAsync(userId);

            var permission = await _context.Set<EventPermission>()
                .Include(p => p.Event)
                .Where(p => p.Event.Code == eventCode && p.IsGranted)
                .Where(p => (p.TargetId == userId && p.TargetType == PermissionTarget.User) ||
                            (userRoles.Contains(p.TargetId) && p.TargetType == PermissionTarget.Role))
                .OrderByDescending(p => p.MaxAmount) // نأخذ الأعلى سقفاً إذا تكررت الصلاحية
                .FirstOrDefaultAsync();

            if (permission == null) return false;

            if (amount.HasValue && permission.MaxAmount.HasValue)
            {
                return amount.Value <= permission.MaxAmount.Value;
            }

            return true;
        }
        public async Task<bool> CheckPermission(Guid userId, string pageName, string actionCode)
        {
            var pageId = await _context.SystemPages
             .Where(p => p.Name == pageName)
             .Select(p => p.Id)
             .FirstOrDefaultAsync();
            if (pageId == Guid.Empty) return false;
            var userRoles = await _identityService.GetUserRolesIdsAsync(userId);

            return await _context.Permissions
            .AnyAsync(p => p.PageId == pageId &&
                           p.ActionCode == actionCode &&
                           p.IsGranted &&
                           ((p.TargetId == userId && p.TargetType == PermissionTarget.User) ||
                            (userRoles.Contains(p.TargetId) && p.TargetType == PermissionTarget.Role)));

        }

        public async Task<List<Permission>> GetByTargetAsync(Guid targetId, PermissionTarget targetType)
        {
            return await _context.Permissions
            .Include(p => p.Page)      // لجلب بيانات الصفحة المرتبطة
            .Include(p => p.Action)    // لجلب بيانات العملية المرتبطة
            .Where(p => p.TargetId == targetId && p.TargetType == targetType)
            .ToListAsync();
        }
        public async Task<List<Permission>> GetPerJustByTargetAsync(Guid targetId, PermissionTarget targetType)
        {
            return await _context.Permissions
            .Where(p => p.TargetId == targetId && p.TargetType == targetType)
             .AsNoTracking()
            .ToListAsync();
        }



        public async Task AddAsync(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
        }

        public async Task UpdateAsync(Permission permission)
        {
            _context.Permissions.Update(permission);
            await Task.CompletedTask;
        }
        public async Task RemoveRangeAsync(List<Permission> permissions)
        {
            _context.Permissions.RemoveRange(permissions);
            await Task.CompletedTask;
        }

        public async Task<List<SystemActionDto>> GutPageActionWithActivation(Guid PageId, CancellationToken ct)
        {
            var assignedActionIds = await _context.PageActions
                .AsNoTracking()
                 .Where(pa => pa.PageId == PageId)
                 .Select(pa => pa.ActionId)
                 .ToListAsync(ct);
            var allActions = await _context.SystemActions
                .AsNoTracking()
                .OrderBy(a => a.SortOrder)
                .Select(a => new SystemActionDto
                {
                    Id = a.Id,
                    Code = a.Code,
                    DisplayName = a.DisplayName,
                    SortOrder = a.SortOrder,
                    IsActive = assignedActionIds.Contains(a.Id)
                })
                .ToListAsync(ct);
            return allActions;
        }
        public async Task RemovePageActionAsync(Guid actionId, Guid pageId, CancellationToken ct)
        {
            var assignedActionIds = await _context.PageActions.Where(pa => pa.ActionId == actionId && pa.PageId == pageId).FirstAsync(ct);
            _context.PageActions.Remove(assignedActionIds);
            await Task.CompletedTask;
        }

        public async Task AddPageActionAsync(PageAction pageAction)
        {
            await _context.PageActions.AddAsync(pageAction);

        }
    }
}
