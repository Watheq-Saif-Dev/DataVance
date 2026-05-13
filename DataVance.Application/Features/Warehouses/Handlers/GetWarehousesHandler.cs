using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Warehouses.DTO;
using DataVance.Application.Features.Warehouses.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace DataVance.Application.Features.Warehouses.Handlers
{
    public class GetWarehousesHandler : IRequestHandler<GetWarehousesQuery, List<WarehouseDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserContext _currentUser;

        public GetWarehousesHandler(IApplicationDbContext context, ICurrentUserContext currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<List<WarehouseDto>> Handle(GetWarehousesQuery request, CancellationToken ct)
        {
            return await _context.Warehouses
                .Where(w => w.BranchId == _currentUser.BranchId)
                .Select(w => new WarehouseDto(w.Id, w.Name, w.Location))
                .ToListAsync(ct);
        }
    }
}

