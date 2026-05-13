using DataVance.Application.Common;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.Security.Queries;
using DataVance.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler.Users
{
    public class GetAllRolesAndUserHandler : IRequestHandler<GetAllTargetQuery, List<LookupItem>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public GetAllRolesAndUserHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }

        public async Task<List<LookupItem>> Handle(GetAllTargetQuery request, CancellationToken cancellationToken)
        {
            var list = new List<TargetLookupDto>();
            if (request.target == PermissionTarget.Role)
            {
                list = await _identityService.GetAllRolesAsync();
            }
            else
            {
                list = await _identityService.GetAllUsersAsync();
            }

            return list.Select(v =>
            new LookupItem
            {
                Id = v.Id,
                Code = v.Name
            }).ToList();

        }
    }
}
