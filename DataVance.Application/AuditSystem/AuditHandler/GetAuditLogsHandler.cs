using DataVance.Application.AuditSystem.DTO;
using DataVance.Application.AuditSystem.Query;
using DataVance.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.AuditHandler
{
    public class GetAuditLogsHandler : IRequestHandler<GetAuditLogsQuery, PaginatedList<AuditLogDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAuditLogsHandler(IApplicationDbContext context) => _context = context;

        public async Task<PaginatedList<AuditLogDto>> Handle(GetAuditLogsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.AuditLogs.AsNoTracking();
            if (!string.IsNullOrEmpty(request.TableName))
                query = query.Where(x => x.TableName == request.TableName);

            if (!string.IsNullOrEmpty(request.SearchUser))
                query = query.Where(x => x.UserEmail.Contains(request.SearchUser));
            var count = await query.CountAsync(cancellationToken);
            var items = await query
                .OrderByDescending(x => x.DateTime)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .Select(log => new AuditLogDto(
                    log.Id,
                    log.UserEmail ?? "System",
                    log.Action,
                    log.TableName,
                    log.Details,
                    log.IpAddress,
                    log.DateTime
                ))
                .ToListAsync(cancellationToken);

            return new PaginatedList<AuditLogDto>(items, count, request.PageNumber, request.PageSize);
        }
    }
}


