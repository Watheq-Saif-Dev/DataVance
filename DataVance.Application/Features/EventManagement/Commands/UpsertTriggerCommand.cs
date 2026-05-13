using DataVance.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.EventManagement.Commands
{

    public record UpsertPermissionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid TargetId { get; set; }
        public PermissionTarget TargetType { get; set; }
        public Guid SystemEventId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? WarehouseId { get; set; }
        public bool IsGranted { get; set; } = true;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxAmount { get; set; }
    }
    public record UpsertSystemEventCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }

    public record UpsertTriggerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string OperationCode { get; set; } = string.Empty;
        public Guid SystemEventId { get; set; }
        public int ExecutionOrder { get; set; }
        public EventImportance Importance { get; set; }
        public bool IsActive { get; set; }
    }
    public record DeleteEntityCommand(Guid Id, string TableName) : IRequest<bool>;
}


