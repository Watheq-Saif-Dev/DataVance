using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.EventManagement.Commands;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Domain.Entities.SecuritySystem;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.EventManagement.Handlers
{
    public class UpsertEventManagementHandler :
        IRequestHandler<UpsertSystemEventCommand, Guid>,
        IRequestHandler<UpsertTriggerCommand, Guid>,
        IRequestHandler<UpsertPermissionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public UpsertEventManagementHandler(IApplicationDbContext context) => _context = context;


        public async Task<Guid> Handle(UpsertPermissionCommand request, CancellationToken ct)
        {
            var entity = await _context.EventPermissions.
                FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (entity == null)
            {
                entity = new EventPermission(
                    request.TargetId,
                    request.TargetType,
                    request.SystemEventId,
                    request.BranchId,
                    request.WarehouseId,
                    request.IsGranted,
                    request.MaxAmount
                );
                _context.EventPermissions.Add(entity);

            }
            else
            {

                if (request.IsGranted) entity.Grant(); else entity.Revoke();
                entity.SetMaxAmount(request.MaxAmount);
                entity.UpdateLocation(request.BranchId, request.WarehouseId);
            }

            await _context.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task<Guid> Handle(UpsertSystemEventCommand request, CancellationToken ct)
        {
            var entity = await _context.SystemEvents
                .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (entity == null)
            {
                entity = new SystemEvent(request.Code!, request.DisplayName!, request.Module!);
                _context.SystemEvents.Add(entity);
            }
            else
            {
                entity.Update(request.Code!, request.DisplayName!, request.Module!);

                if (request.IsActive) entity.Activate(); else entity.Deactivate();
            }
            await _context.SaveChangesAsync(ct);

            return entity.Id;

        }
        public async Task<Guid> Handle(UpsertTriggerCommand request, CancellationToken ct)
        {
            var entity = await _context.EventTriggers.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (entity == null)
            {
                entity = new EventTrigger(
                    request.OperationCode,
                    request.SystemEventId,
                    request.ExecutionOrder,
                    request.Importance
                );
                _context.EventTriggers.Add(entity);
            }
            else
            {
                entity.Update(
                    request.OperationCode,
                    request.SystemEventId,
                    request.ExecutionOrder,
                    request.Importance
                );

                if (request.IsActive)
                    entity.Activate();
                else
                    entity.Deactivate();
            }
            await _context.SaveChangesAsync(ct);
            return entity.Id;
        }
    }
}

