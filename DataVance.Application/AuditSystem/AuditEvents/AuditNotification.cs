using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.AuditEvents
{
    public record AuditNotification(
        string UserId,
        string? UserEmail,
        string Action,
        string TableName,
        string? OldValuesJson,
        string? NewValuesJson,
        string Details
    ) : INotification;


}


