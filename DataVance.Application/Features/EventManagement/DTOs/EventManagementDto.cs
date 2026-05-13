using System;
using System.Collections.Generic;

namespace DataVance.Application.Features.EventManagement.DTOs
{
    public record SystemEventDto(
        Guid Id,
        string Code,
        string DisplayName,
        string Module,
        bool IsActive,
        bool IsGlobal
    );

    public record EventTriggerDto(
        Guid Id,
        string OperationCode,
        Guid SystemEventId,
        string EventName,
        int ExecutionOrder,
        bool IsActive
    );

    public record EventPermissionDto(
        Guid Id,
        Guid TargetId,
        string TargetType,
        Guid SystemEventId,
        string EventName,
        Guid? BranchId,
        Guid? WarehouseId,
        bool IsGranted,
        decimal? MaxAmount
    );

    public record EventManagementDto(
        List<SystemEventDto> Events,
        List<EventTriggerDto> Triggers,
        List<EventPermissionDto> Permissions,
        List<string> AvailableCommands
    )
    {
        public EventManagementDto() : this(new(), new(), new(), new()) { }
    }
}
