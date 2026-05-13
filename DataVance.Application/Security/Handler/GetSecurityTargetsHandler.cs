using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.Security.Queries;
using DataVance.Domain.Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler
{
    public class GetSecurityTargetsHandler : IRequestHandler<GetSecurityTargetsQuery, List<TargetLookupDto>>
    {
        private readonly IIdentityService _identityService;
        public GetSecurityTargetsHandler(IIdentityService identityService) => _identityService = identityService;


        public async Task<List<TargetLookupDto>> Handle(GetSecurityTargetsQuery request, CancellationToken ct)
        {
            if (request.TargetType == PermissionTarget.Role)
            {
                return await _identityService.GetAllRolesAsync();
            }

            return await _identityService.GetAllUsersAsync();
        }

    }
}
