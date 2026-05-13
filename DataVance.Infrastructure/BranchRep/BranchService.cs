using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.SharedAgg.BrancheSystem.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.BranchRep
{
    public class BranchService : IBranchService
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserContext _currentUser;

        public BranchService(IApplicationDbContext context, IIdentityService identityService, ICurrentUserContext currentUser)

        {
            _context = context;
            _identityService = identityService;
            _currentUser = currentUser;
        }



        // جلب جميع الفروع (عادة للمدير العام)
        public async Task<List<BranchDto>> GetAllBranchesAsync()
        {
            return await _context.Branches
                .IgnoreQueryFilters()
                .AsNoTracking()
                .Select(b => new BranchDto(b.Id, b.Name, b.Code))
                .ToListAsync();
        }



        public async Task<BranchDto?> GetBranchByIdAsync(Guid id)
        {
            var branch = await _context.Branches.FindAsync(id);
            return branch != null ? new BranchDto(branch.Id, branch.Name, branch.Code) : null;
        }



        public async Task<List<BranchDto>> GetUserBranchesAsync(Guid userId)
        {
            return await _context.UserBranches
                .Where(ub => ub.UserId == userId)
                .Select(ub => new BranchDto(ub.Branch.Id, ub.Branch.Name, ub.Branch.Code))
                .ToListAsync();
        }

        public async Task<bool> IsUserInBranchAsync(Guid userId, Guid branchId)
        {
            return await _context.UserBranches
                .AnyAsync(ub => ub.UserId == userId && ub.BranchId == branchId);
        }

        public async Task<List<BranchDto>> GetUserAssignedBranchesAsync(Guid userId)
        {


            return await _context.UserBranches
                .Where(ub => ub.UserId == userId)
                .Select(ub => new BranchDto(ub.BranchId, ub.Branch.Name, ub.Branch.Code))
                .ToListAsync();
        }

        public async Task<List<BranchDto>> GetBranchesByEmailAsync(string email)
        {
            // 1. جلب معرف المستخدم عبر الخدمة الوسيطة
            var userId = await _identityService.GetUserIdByEmailAsync(email);
            if (userId == null) return new List<BranchDto>();

            // 2. جلب الفروع (تصحيح خطأ الـ Constructor للـ Record)
            return await _context.UserBranches
                .AsNoTracking()
                .Where(ub => ub.UserId == userId.Value)
                .Select(ub => new BranchDto(ub.BranchId, ub.Branch.Name, ub.Branch.Code))
                .ToListAsync();
        }

    }
}

