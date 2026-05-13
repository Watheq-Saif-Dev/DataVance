using DataVance.Application.AuditSystem.AuditEvents;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Entities.AuditSystem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.AuditHandler
{

    public class AuditLogHandler : INotificationHandler<AuditNotification>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserContext _currentUser;


        public AuditLogHandler(IApplicationDbContext context, ICurrentUserContext currentUser)
        {
            _context = context;
            _currentUser = currentUser;

        }

        public async Task Handle(AuditNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                var auditEntry = new AuditLog
                {
                    UserId = Guid.TryParse(notification.UserId, out var guid) ? guid : Guid.Empty,
                    UserEmail = notification.UserEmail ?? "System",
                    Action = notification.Action,
                    TableName = notification.TableName,
                    Details = notification.Details,
                    OldValues = notification.OldValuesJson,
                    NewValues = notification.NewValuesJson,
                    DateTime = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    CreatedBy = notification.UserEmail ?? "System",
                    IpAddress = _currentUser.IpAddress,
                    DeviceInfo = $"DeviceName: {_currentUser.DeviceName} + UserAgent: {_currentUser.UserAgent}"

                };
                _context.AuditLogs.Add(auditEntry);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ في حفظ سجل التدقيق: {ex.Message}");
            }
        }
    }
}

