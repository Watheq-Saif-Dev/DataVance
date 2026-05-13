using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Service;
using Microsoft.AspNetCore.Components;

namespace DataVance.Components.Shared
{
    public class PermissionPageBase : ComponentBase
    {
        [Inject] public IPermissionService PermissionService { get; set; }
        [Inject] public ICurrentUserContext CurrentUserService { get; set; }
        [Inject] public NavigationManager Nav { get; set; }
        protected async Task<bool> CheckPagePermission(string pageCode, string actionCode = "View")
        {
            var hasIdentity = CurrentUserService.UserId != Guid.Empty;
            var isAuthorized = hasIdentity && await PermissionService.CheckPermission(CurrentUserService.UserId, pageCode, actionCode);

            if (!isAuthorized)
            {
                Nav.NavigateTo("/access-denied");
                return false;
            }
            return true;
        }
    }
}

