using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Commands;
using DataVance.Domain.Common.Models;

using DataVance.Domain.Entities.UserSystem;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataVance.Application.Security.Handler
{
    public class UpdateUserLinkBranchWithRoleHandler : IRequestHandler<UpdateUserLinkBranchWithRoleCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public UpdateUserLinkBranchWithRoleHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }

        public async Task<Result> Handle(UpdateUserLinkBranchWithRoleCommand request, CancellationToken ct)
        {
            if (request.BranchId.HasValue && request.IsAssigned.HasValue)
            {
                if (request.IsAssigned.Value)
                {
                    var exists = await _context.UserBranches.AnyAsync(ub => ub.UserId == request.UserId && ub.BranchId == request.BranchId, ct);
                    if (!exists) _context.UserBranches.Add(new UserBranch { UserId = request.UserId, BranchId = request.BranchId.Value });
                }
                else
                {
                    var record = await _context.UserBranches.FirstOrDefaultAsync(ub => ub.UserId == request.UserId && ub.BranchId == request.BranchId, ct);
                    if (record != null) _context.UserBranches.Remove(record);
                }
            }
            if (!string.IsNullOrEmpty(request.RoleName))
            {
                return await _identityService.AssignUserToRoleAsync(request.UserId, request.RoleName);
            }

            await _context.SaveChangesAsync(ct);
            return Result.Success();
        }
    }
}

