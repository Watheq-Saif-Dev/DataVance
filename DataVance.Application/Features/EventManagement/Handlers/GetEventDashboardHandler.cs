using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.EventManagement.DTOs;
using DataVance.Application.Features.EventManagement.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.EventManagement.Handlers
{

    public class GetEventDashboardHandler : IRequestHandler<GetEventDashboardQuery, EventManagementDto>
    {
        private readonly IApplicationDbContext _context;

        public GetEventDashboardHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<EventManagementDto> Handle(GetEventDashboardQuery request, CancellationToken ct)
        {
            var events = await _context.SystemEvents.AsNoTracking().ToListAsync(ct);
            var triggers = await _context.EventTriggers.Include(x => x.Event).AsNoTracking().ToListAsync(ct);
            var permissions = await _context.EventPermissions.Include(x => x.Event).AsNoTracking().ToListAsync(ct);
            var applicationAssembly = typeof(GetEventDashboardQuery).Assembly;

            var commandNames = applicationAssembly.GetTypes()
                .Where(p => !p.IsAbstract && !p.IsInterface &&
                            p.GetInterfaces().Any(i => i.IsGenericType &&
                            (i.GetGenericTypeDefinition() == typeof(IRequest<>) ||
                             i.GetGenericTypeDefinition() == typeof(IRequest))))
                .Select(t => t.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            var eventDtos = events.Select(e => new SystemEventDto(e.Id, e.Code ?? "", e.DisplayName ?? "", e.Module ?? "", e.IsActive, e.IsGlobal)).ToList();
            var triggerDtos = triggers.Select(t => new EventTriggerDto(t.Id, t.OperationCode, t.SystemEventId, t.Event?.DisplayName ?? "", t.ExecutionOrder, t.IsActive)).ToList();
            var permissionDtos = permissions.Select(p => new EventPermissionDto(p.Id, p.TargetId, p.TargetType.ToString(), p.SystemEventId, p.Event?.DisplayName ?? "", p.BranchId, p.WarehouseId, p.IsGranted, p.MaxAmount)).ToList();

            return new EventManagementDto(eventDtos, triggerDtos, permissionDtos, commandNames);
        }

    }
}


