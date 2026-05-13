using DataVance.Domain.Common.Models;
using MediatR;

namespace DataVance.Application.Security.Commands
{
    public record UpdateUserLinkBranchWithRoleCommand(
       Guid UserId,
       Guid? BranchId = null,
       bool? IsAssigned = null,
       string? RoleName = null
   ) : IRequest<Result>;
}
