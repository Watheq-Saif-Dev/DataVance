using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.DTO;
using DataVance.Application.Security.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler.Pages
{
    public class GetAllPagesHandler : IRequestHandler<GetAllPagesQuery, List<SystemPageDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPagesHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SystemPageDto>> Handle(GetAllPagesQuery request, CancellationToken cancellationToken)
        {

            return await _context.SystemPages
                .AsNoTracking()
                .Select(p => new SystemPageDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    DisplayName = p.DisplayName,
                    ModuleName = p.ModuleName,
                    Icon = p.Icon,
                    AvailableActions = p.AvailableActions.Select(a => new PageActionDto
                    {
                        ActionId = a.ActionId,
                        IsActive = true
                    }).ToList()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
