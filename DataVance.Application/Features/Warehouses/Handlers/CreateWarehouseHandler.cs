using DataVance.Application.AuditSystem.AuditEvents;
using DataVance.Application.AuditSystem.Service;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Service;
using DataVance.Application.Features.Warehouses.Commands;
using DataVance.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Handlers
{
    public class CreateWarehouseHandler : IRequestHandler<CreateWarehouseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserContext _currentUser;
        private readonly IAuditService _auditService;
        private readonly IOperationEventExecutor _executor;

        public CreateWarehouseHandler(IApplicationDbContext context, ICurrentUserContext currentUser, IAuditService auditService, IOperationEventExecutor executor)
        {
            _context = context;
            _currentUser = currentUser;
            _auditService = auditService;
            _executor = executor;
        }

        public Task<Guid> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}



