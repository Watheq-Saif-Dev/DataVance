using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Warehouses.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Handlers
{
    public class DeleteWarehouseHandler : IRequestHandler<DeleteWarehouseCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserContext _currentUser;

        public DeleteWarehouseHandler(IApplicationDbContext context, ICurrentUserContext currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken ct)
        {
            var warehouse = await
                _context.Warehouses.FirstOrDefaultAsync(w => w.Id == request.Id && w.BranchId == _currentUser.BranchId, ct);
            if (warehouse == null) return false;

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
