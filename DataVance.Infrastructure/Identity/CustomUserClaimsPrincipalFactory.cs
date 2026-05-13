using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using DataVance.Infrastructure.Identity;

namespace DataVance.Infrastructure.Identity
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole<Guid>>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            if (user.LastSelectedBranchId != null)
            {
                // إضافة الفرع كـ Claim رسمي. هذا السطر يجعله "يُخزن" في المتصفح للأبد (حتى تنتهي الكوكي)
                identity.AddClaim(new Claim("BranchId", user.LastSelectedBranchId.ToString()!));
                identity.AddClaim(new Claim("BranchName", user.LastSelectedBranchName!));
            }

            return identity;
        }
    }
}
