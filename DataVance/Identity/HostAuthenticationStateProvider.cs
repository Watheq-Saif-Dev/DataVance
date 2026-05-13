using DataVance.Infrastructure.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DataVance.Identity
{
    public class HostAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HostAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var user = _httpContextAccessor.HttpContext?.User;


            if (user == null || user.Identity?.IsAuthenticated != true)
            {
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }


            return Task.FromResult(new AuthenticationState(user));
        }
    }














}

