using DataVance.Application.AuditSystem.AuditEvents;
using DataVance.Application.AuditSystem.Service;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace DataVance.Application.Security.Service
{
    public class AuditService : IAuditService
    {
        private readonly IPublisher _publisher;
        private readonly ICurrentUserContext _currentUser;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public AuditService(IPublisher publisher, ICurrentUserContext currentUser)
        {
            _publisher = publisher;
            _currentUser = currentUser;
        }
        public async Task LogCreateAsync<TRequest, TEntity>(TRequest request, TEntity entity)
        {
            var tableName = GetTableName(entity);
            var newJson = JsonSerializer.Serialize(entity, _jsonOptions);

            var details = $"إضافة سجل جديد في {tableName}";

            await _publisher.Publish(new AuditNotification(
                UserId: _currentUser.UserId.ToString(),
                UserEmail: _currentUser.UserName ?? "System",
                Action: "Create",
                TableName: tableName,
                OldValuesJson: null,
                NewValuesJson: newJson,
                Details: details
            ));
        }
        public async Task LogUpdateAsync<TRequest, TEntity>(TRequest request, TEntity newValues, TEntity oldValues)
        {
            var tableName = GetTableName(newValues);

            var oldJson = oldValues != null ? JsonSerializer.Serialize(oldValues, _jsonOptions) : null;
            var newJson = newValues != null ? JsonSerializer.Serialize(newValues, _jsonOptions) : null;

            var details = $"تعديل بيانات في {tableName}";

            await _publisher.Publish(new AuditNotification(
                UserId: _currentUser.UserId.ToString(),
                UserEmail: _currentUser.UserName ?? "System",
                Action: "Update",
                TableName: tableName,
                OldValuesJson: oldJson,
                NewValuesJson: newJson,
                Details: details
            ));
        }
        public async Task LogDeleteAsync<TRequest, TEntity>(TRequest request, TEntity entity)
        {
            var tableName = GetTableName(entity);
            var oldJson = JsonSerializer.Serialize(entity, _jsonOptions);

            var details = $"حذف سجل من {tableName}";

            await _publisher.Publish(new AuditNotification(
                UserId: _currentUser.UserId.ToString(),
                UserEmail: _currentUser.UserName ?? "System",
                Action: "Delete",
                TableName: tableName,
                OldValuesJson: oldJson,
                NewValuesJson: null,
                Details: details
            ));
        }
        private string GetTableName<T>(T entity)
        {
            if (entity == null) return typeof(T).Name;
            if (entity is System.Collections.IEnumerable && !(entity is string))
            {
                var type = entity.GetType();
                if (type.IsGenericType)
                {
                    return $"{type.GetGenericArguments()[0].Name} (List)";
                }
                return "BulkItems";
            }

            return entity.GetType().Name;
        }

        public async Task LogIntentAsync<TRequest>(TRequest request, string action)
        {
            try
            {
                var requestJson = JsonSerializer.Serialize(request, _jsonOptions);
                var tableName = request.GetType().Name;
                var auditNotification = new AuditNotification(
                    UserId: _currentUser.UserId.ToString(),
                    UserEmail: _currentUser.UserName ?? "System",
                    Action: action,
                    TableName: tableName,
                    OldValuesJson: null,
                    NewValuesJson: requestJson,
                    Details: $"تشغيل عملية تلقائية: {action}"
                );
                await _publisher.Publish(auditNotification);
            }
            catch (Exception)
            {
                throw new Exception("لم يتم تسجيل العملية في سجل العمليات ");
            }
        }

        public Task LogUpdateAsync<TRequest, TEntity>(TRequest request, TEntity newEntity, Guid id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task LogAsync<TRequest, TEntity>(TRequest request, TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }


    }
}


