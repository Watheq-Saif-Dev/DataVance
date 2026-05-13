using DataVance.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Services
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // خاصية مساعدة للوصول للمستخدم الحالي بأمان
        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public Guid UserId => GetGuidClaim(ClaimTypes.NameIdentifier);

        public Guid BranchId
        {
            get
            {
                var val = GetStringClaim("BranchId");
                return Guid.TryParse(val, out var result) ? result : Guid.Empty;
            }
        }

        public string BranchName => User?.FindFirstValue("BranchName") ?? "غير محدد";

        public string UserName => User?.Identity?.Name ?? "Guest";

        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;


        public string? IpAddress => _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        public string? UserAgent => _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"];
        public string? DeviceName => _httpContextAccessor.HttpContext?.Request.Headers["Sec-Ch-Ua-Platform"];
        public event Func<Task>? OnChangeAsync;


        private string? GetStringClaim(string claimType)
        {
            // FindFirstValue هي دالة آمنة تعيد null إذا لم تجد الـ Claim
            return User?.FindFirstValue(claimType);
        }

        private Guid GetGuidClaim(string claimType)
        {
            var value = GetStringClaim(claimType);
            return Guid.TryParse(value, out var result) ? result : Guid.Empty;
        }

    }
}
