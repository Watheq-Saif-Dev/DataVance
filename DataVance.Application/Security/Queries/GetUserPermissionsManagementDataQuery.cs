using DataVance.Application.Common;
using DataVance.Application.DTOs;
using DataVance.Application.Security.DTO;
using DataVance.Domain.Entities.Enums;
using MediatR;

namespace DataVance.Application.Security.Queries
{
    public record GetUserPermissionsManagementDataQuery : IRequest<UserPermissionsVm>;
    public record UserPermissionsVm(List<UserWithBranchDto> Users, List<BranchDto> AllBranches);
    public record GetAllPagesQuery : IRequest<List<SystemPageDto>>
    {
    }

    public class GetPermissionsByTargetQuery : IRequest<List<SystemPageDto>>
    {
        public Guid TargetId { get; set; }
        public PermissionTarget TargetType { get; set; }

        public GetPermissionsByTargetQuery(Guid targetId, PermissionTarget targetType)
        {
            TargetId = targetId;
            TargetType = targetType;
        }
    }
    public record GetPageActionsQuery(Guid pageId) : IRequest<List<SystemActionDto>>;
    public class GetUserPagePermissionsQuery : IRequest<List<PermissionDto>>
    {
        public string PageName { get; set; }
    }
    public record GetAllTargetQuery(PermissionTarget target) : IRequest<List<LookupItem>>;
}


