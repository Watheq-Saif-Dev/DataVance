using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Events;
using DataVance.Domain.Entities.AuditSystem;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.AuditHandler
{
    public class SystemAuditHandler : INotificationHandler<SystemEventNotification>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<SystemAuditHandler> _logger;
        private readonly ICurrentUserContext _currentUser;

        public SystemAuditHandler(IApplicationDbContext context, ILogger<SystemAuditHandler> logger, ICurrentUserContext currentUser)
        {
            _context = context;
            _logger = logger;
            _currentUser = currentUser;
        }

        public async Task Handle(SystemEventNotification notification, CancellationToken ct)
        {
            if (!notification.EventCode.EndsWith("Audit"))
                return;

            try
            {
                using var doc = JsonDocument.Parse(notification.PayloadJson);
                var root = doc.RootElement;
                var auditEntry = new AuditLog
                {

                    Action = notification.EventCode,
                    DateTime = DateTime.UtcNow,
                    UserId = notification.UserId,
                    UserEmail = notification.UserEmail,
                    KeyValues = root.TryGetProperty("Id", out var idExtra) ? idExtra.ToString() : null,
                    Details = notification.PayloadJson,
                    TableName = ExtractTableName(notification.EventCode),
                    NewValues = notification.PayloadJson,
                    IpAddress = root.TryGetProperty("IpAddress", out var ip) ? ip.ToString() : "::1"
                };

                _context.AuditLogs.Add(auditEntry);
                _logger.LogInformation($"✅ [System Audit] تم أرشفة الحدث: {notification.EventCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ [Audit Error] فشل الأرشفة لـ {notification.EventCode}: {ex.Message}");
            }
        }
        private string ExtractTableName(string eventCode)
        {
            return eventCode.Replace("Create", "").Replace("Update", "").Replace("Delete", "").Replace("Audit", "");
        }
    }
}


