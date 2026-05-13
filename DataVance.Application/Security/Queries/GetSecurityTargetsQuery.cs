using DataVance.Application.DTOs;
using DataVance.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Queries
{
    public record GetSecurityTargetsQuery(PermissionTarget TargetType) : IRequest<List<TargetLookupDto>>;
}
