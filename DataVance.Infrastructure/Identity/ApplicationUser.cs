using Microsoft.AspNetCore.Identity;
namespace DataVance.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public Guid? LastSelectedBranchId { get; set; }
        public string? LastSelectedBranchName { get; set; } = string.Empty;

    }
}
