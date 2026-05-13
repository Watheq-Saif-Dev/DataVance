using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Service;
using DataVance.Domain.Entities.Enums;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.EventManagement.Services
{
    public class EventAuthorizationService : IEventAuthorizationService
    {
        private readonly IApplicationDbContext _context;

        public EventAuthorizationService(IApplicationDbContext context) => _context = context;


        public async Task<bool> AuthorizeAsync(Guid? userId, string eventCode)
        {
            if (!userId.HasValue) return false;

            // 1. جلب بيانات الحدث
            var systemEvent = await _context.SystemEvents
                .FirstOrDefaultAsync(e => e.Code == eventCode && e.IsActive);

            if (systemEvent == null) return false;
            if (systemEvent.IsGlobal) return true; // إذا كان عاماً مسموح للكل

            // 2. التحقق من جدول الـ EventPermissions
            var userRoles = await _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToListAsync();

            return await _context.EventPermissions
                .AnyAsync(p => p.SystemEventId == systemEvent.Id && p.IsGranted &&
                              (p.TargetType == PermissionTarget.User && p.TargetId == userId ||
                               p.TargetType == PermissionTarget.Role && userRoles.Contains(p.TargetId)));
        }
    }
}

