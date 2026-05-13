using DataVance.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.BrancheSystem.Service
{
    public interface IBranchService
    {
        Task<List<BranchDto>> GetAllBranchesAsync();
        Task<BranchDto?> GetBranchByIdAsync(Guid id);
        Task<List<BranchDto>> GetUserBranchesAsync(Guid userId);
        Task<bool> IsUserInBranchAsync(Guid userId, Guid branchId);
        Task<List<BranchDto>> GetUserAssignedBranchesAsync(Guid userId);
        Task<List<BranchDto>> GetBranchesByEmailAsync(string email);

    }
}
