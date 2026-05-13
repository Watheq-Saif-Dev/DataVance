using DataVance.Application.AlertServices;
using DataVance.Application.AuditSystem.Service;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.Security.Commands;
using DataVance.Application.Security.Service;
using MediatR;
using System.Reflection;
namespace DataVance.Application.Common.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {

        private readonly ICurrentUserContext _user;
        private readonly IPermissionService _permissionService;

        public AuthorizationBehavior(ICurrentUserContext user, IPermissionService permissionService)
        {
            _user = user;
            _permissionService = permissionService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            var authAttributes = request.GetType().GetCustomAttributes<HasPermissionAttribute>();
            if (!authAttributes.Any()) return await next();

            if (_user.UserId == Guid.Empty) throw new UnauthorizedAccessException("يجب تسجيل الدخول أولاً");
            if (_user.BranchId == Guid.Empty) throw new UnauthorizedAccessException("يجب يجب تسجيل الخروج واعاده تسجيل الدخول والمحاولة مرة اخراء....");

            foreach (var attr in authAttributes)
            {
                var authorized = await _permissionService.CheckPermission(_user.UserId, attr.PageCode, attr.ActionCode);
                if (!authorized) throw new UnauthorizedAccessException($"ليس لديك صلاحية: {attr.ActionCode}");
            }

            return await next();
        }


    }
}

