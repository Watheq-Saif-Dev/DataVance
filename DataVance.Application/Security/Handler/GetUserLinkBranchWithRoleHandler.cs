using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.DTO;
using DataVance.Application.Security.Queries;
using DataVance.Application.SharedAgg.BrancheSystem.Quer;
using DataVance.Application.SharedAgg.BrancheSystem.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataVance.Application.Security.Handler
{
    public class GetUserLinkBranchWithRoleHandler : IRequestHandler<GetUserPermissionsManagementDataQuery, UserPermissionsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly IBranchService _branchService;


        public GetUserLinkBranchWithRoleHandler(IApplicationDbContext context, IIdentityService identityService, IBranchService branchService)
        {
            _context = context;
            _identityService = identityService;
            _branchService = branchService;

        }

        public async Task<UserPermissionsVm> Handle(GetUserPermissionsManagementDataQuery request, CancellationToken ct)
        {
            var allBranches = await _branchService.GetAllBranchesAsync();
            var rawUsers = await _identityService.GetAllUsersAsync();
            var allUserBranches = await _context.UserBranches.AsNoTracking().ToListAsync(ct);
            var usersWithPermissions = rawUsers.Select(u => new UserWithBranchDto(
                u.Id,
                u.Name,
                allUserBranches.Where(ub => ub.UserId == u.Id).Select(ub => ub.BranchId).ToList()
            )).ToList();

            return new UserPermissionsVm(usersWithPermissions, allBranches);
        }
    }
}

