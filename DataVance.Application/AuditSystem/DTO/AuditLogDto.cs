using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.DTO
{
    public record AuditLogDto(
    Guid Id,
    string UserEmail,
    string Action,
    string Details,
string TableName,
    string IpAddress,
    DateTime CreatedAt);
}
