using DataVance.Application.AuditSystem.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.Query
{
    public record GetAuditLogsQuery(int PageNumber, int PageSize, string? TableName, string? SearchUser)
        : IRequest<PaginatedList<AuditLogDto>>;
}
