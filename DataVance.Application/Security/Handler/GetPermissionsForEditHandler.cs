using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.Security.DTO;
using DataVance.Application.Security.DTO.Models;

using DataVance.Application.Security.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler
{
    public class GetPermissionsForEditHandler : IRequestHandler<GetPermissionsForEditQuery, PermissionsEditViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetPermissionsForEditHandler(IApplicationDbContext context) => _context = context;

        public async Task<PermissionsEditViewModel> Handle(GetPermissionsForEditQuery request, CancellationToken ct)
        {
            var allActions = await _context.SystemActions
                .OrderBy(x => x.SortOrder)
                .Select(x => new ActionDto(x.Id, x.Code, x.DisplayName))
                .ToListAsync(ct);
            var allPages = await _context.SystemPages
                .OrderBy(x => x.DisplayName)
                .ToListAsync(ct);
            var currentPermissions = await _context.Permissions
                .Where(x => x.PageId == request.TargetId && x.TargetType == request.TargetType && x.IsGranted)
                .ToListAsync(ct);
            var rows = allPages.Select(page => new PagePermissionRowDto(page.Id, page.DisplayName)
            {
                GrantedActionCodes = currentPermissions
                    .Where(p => p.PageId == page.Id)
                    .Select(p => p.ActionCode)
                    .ToList()
            }).ToList();

            return new PermissionsEditViewModel
            {
                AllActions = allActions,
                Rows = rows
            };
        }
    }
}


