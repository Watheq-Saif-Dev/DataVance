using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Domain.Common.Models;

//using DataVance.Domain.Common.Models;
using DataVance.Infrastructure.Identity;
using DataVance.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace DataVance.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly ApplicationDbContext _context;

        public IdentityService(SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,

                                RoleManager<IdentityRole<Guid>> roleManager,
                               IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
                               ApplicationDbContext context
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;

            _roleManager = roleManager;
            _claimsFactory = claimsFactory;
            _context = context;
        }
        public async Task<List<TargetLookupDto>> GetAllUsersAsync()
        {
            return await _userManager.Users
                .Select(u => new TargetLookupDto(u.Id, u.UserName!))
                .ToListAsync();
        }

        public async Task<List<TargetLookupDto>> GetAllRolesAsync()
        {
            return await _roleManager.Roles
                .Select(r => new TargetLookupDto(r.Id, r.Name!))
                .ToListAsync();
        }

        public async Task<string?> GetUserNameAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user?.UserName;
        }

        public async Task<List<Guid>> GetUserRolesIdsAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return new List<Guid>();
            var roleNames = await _userManager.GetRolesAsync(user);
            return await _roleManager.Roles
                .Where(r => roleNames.Contains(r.Name!))
                .Select(r => r.Id)
                .ToListAsync();
            //roleIds;
        }
        //Check Credentials Async

        public async Task<bool> CheckCredentialsAsync(string email, string password, Guid branchId)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var passwordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordValid) return false;

            var hasBranchAccess = await _context.UserBranches
                .AnyAsync(ub => ub.UserId == user.Id && ub.BranchId == branchId);

            return hasBranchAccess;
        }

        public async Task<bool> LoginAsync(string email, string password, Guid branchId)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded) return false;



            var branch = await _context.Branches
                         .AsNoTracking() // أداء أسرع
                         .FirstOrDefaultAsync(b => b.Id == branchId);
            if (branch == null) return false;

            var hasBranchAccess = await _context.UserBranches
            .AnyAsync(ub => ub.UserId == user.Id && ub.BranchId == branchId);

            if (!hasBranchAccess) return false;

            user.LastSelectedBranchId = branchId;
            user.LastSelectedBranchName = branch.Name;
            await _userManager.UpdateAsync(user);


            var principal = await _claimsFactory.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity!;

            // 4. إضافة بيانات الفرع (المعلومات المتغيرة حسب الجلسة)
            //identity.AddClaim(new Claim("BranchId", branchId.ToString()));
            //identity.AddClaim(new Claim("BranchName", branch.Name));
            //if (!identity.HasClaim(c => c.Type == "BranchName"))
            //{
            //    identity.AddClaim(new Claim("BranchName", branch.Name));
            //}
            await _signInManager.Context.SignInAsync(
                                         IdentityConstants.ApplicationScheme,
                                         principal,
                                         new AuthenticationProperties
                                         {
                                             IsPersistent = true,
                                             ExpiresUtc = DateTimeOffset.UtcNow.AddHours(7) // تحديد مدة الصلاحية
                                         });

            return true;
        }
        //public async Task<bool> LoginAsync(string email, string password, Guid branchId)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null) return false;

        //    var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        //    if (result.Succeeded)
        //    {

        //        var branch = await _context.Branches.FindAsync(branchId);
        //        var branchName = branch?.Name ?? "Unknown";
        //        var hasBranchAccess = await _context.UserBranches
        //.AnyAsync(ub => ub.UserId == user.Id && ub.BranchId == branchId);

        //        if (!hasBranchAccess)
        //        {
        //            // إذا لم يكن له صلاحية على هذا الفرع، نرفض تسجيل الدخول فوراً
        //            return false;
        //        }
        //        var principal = await _claimsFactory.CreateAsync(user);
        //        var identity = (ClaimsIdentity)principal.Identity!;
        //        identity.AddClaim(new Claim("BranchId", branchId.ToString()));
        //        identity.AddClaim(new Claim("BranchName", branchName));

        //        await _signInManager.Context.SignInAsync(
        //            IdentityConstants.ApplicationScheme,
        //            principal,
        //            new AuthenticationProperties { IsPersistent = true });

        //        return true;
        //    }
        //    return false;
        //}

        public async Task<Guid?> GetUserIdByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user?.Id;
        }

        public async Task<Guid?> VerifyUserCredentials(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user.Id;
            }
            return null;
        }


        public async Task<bool> IsInRoleAsync(Guid userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<Result> CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return Result.Failure(new[] { "هذا الدور موجود مسبقاً." });

            var result = await _roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
            return result.Succeeded ? Result.Success() : Result.Failure(result.Errors.Select(e => e.Description));
        }


        public async Task<Result> AssignUserToRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return Result.Failure(new[] { "المستخدم غير موجود" });

            // التحقق إذا كان المستخدم في الرتبة فعلاً لتجنب الخطأ
            if (await _userManager.IsInRoleAsync(user, roleName))
                return Result.Success();

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }

        //public async Task<string?> GetUserNameAsync(Guid userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId.ToString());
        //    return user?.UserName; // أو user?.Email حسب رغبتك
        //}
    }
}
