using DataVance.Application.Security.DTO.Models;
using DataVance.Domain.Entities.Enums;
using MediatR;
namespace DataVance.Application.Security.Queries
{

    public record GetPermissionsForEditQuery(Guid TargetId, PermissionTarget TargetType)
  : IRequest<PermissionsEditViewModel>;
}


