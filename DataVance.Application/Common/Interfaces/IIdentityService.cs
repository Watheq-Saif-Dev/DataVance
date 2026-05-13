using DataVance.Application.DTOs;
using DataVance.Domain.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> LoginAsync(string email, string password, Guid selectedBranchId);
        Task<Guid?> GetUserIdByEmailAsync(string email);
        Task<Guid?> VerifyUserCredentials(string email, string password);
        Task<bool> CheckCredentialsAsync(string email, string password, Guid branchId);
        Task<bool> IsInRoleAsync(Guid userId, string role);
        Task<Result> CreateRoleAsync(string roleName);
        Task<Result> AssignUserToRoleAsync(Guid userId, string roleName);
        Task<string?> GetUserNameAsync(Guid userId);


        Task<List<Guid>> GetUserRolesIdsAsync(Guid userId);
        Task<List<TargetLookupDto>> GetAllUsersAsync();
        Task<List<TargetLookupDto>> GetAllRolesAsync();
    }
}
