using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.DTO;
using DataVance.Application.Security.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler.Permissions
{
    public class GetPermissionsByTargetQueryHandler : IRequestHandler<GetPermissionsByTargetQuery, List<SystemPageDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPermissionsByTargetQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SystemPageDto>> Handle(GetPermissionsByTargetQuery request, CancellationToken ct)
        {
            var allSystemActions = await _context.SystemActions.OrderBy(x => x.SortOrder).ToListAsync(ct);
            var pagesWithActions = await _context.SystemPages
                .Include(p => p.AvailableActions)
                .ToListAsync(ct);
            var currentPermissions = await _context.Permissions
                .Where(p => p.TargetId == request.TargetId && p.TargetType == request.TargetType && p.IsGranted)
                .ToListAsync(ct);
            return pagesWithActions.Select(page => new SystemPageDto
            {
                Id = page.Id,
                DisplayName = page.DisplayName,
                ModuleName = page.ModuleName,
                AvailableActions = allSystemActions.Select(action => new PageActionDto
                {
                    ActionId = action.Id,
                    ActionCode = action.Code,
                    DisplayName = action.DisplayName,
                    IsActive = page.AvailableActions.Any(pa => pa.ActionId == action.Id),
                    IsGranted = currentPermissions.Any(cp => cp.PageId == page.Id && cp.ActionId == action.Id)
                }).ToList()
            }).ToList();
        }

    }

}

