using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.AuditEvents
{
    public class RollbackAuditHandler : IRequestHandler<RollbackAuditCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly JsonSerializerOptions _jsonOptions = new() { ReferenceHandler = ReferenceHandler.IgnoreCycles };

        public RollbackAuditHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RollbackAuditCommand request, CancellationToken cancellationToken)
        {
            var log = await _context.AuditLogs.FindAsync(new object[] { request.LogId }, cancellationToken);
            if (log == null || string.IsNullOrEmpty(log.OldValues)) return false;
            var entityAssembly = typeof(IApplicationDbContext).Assembly;
            var entityName = log.TableName.Replace(" (List)", "").Trim();
            var entityType = entityAssembly.GetTypes().FirstOrDefault(t => t.Name == entityName);

            if (entityType == null) return false;

            try
            {
                bool isList = log.OldValues.TrimStart().StartsWith("[");

                if (isList)
                {
                    var listType = typeof(List<>).MakeGenericType(entityType);
                    var oldItems = JsonSerializer.Deserialize(log.OldValues, listType, _jsonOptions) as IEnumerable;

                    if (oldItems != null)
                    {
                        foreach (var item in oldItems)
                        {
                            _context.Entry(item).State = EntityState.Added;
                        }
                    }
                }
                else
                {
                    var oldEntity = JsonSerializer.Deserialize(log.OldValues, entityType, _jsonOptions);
                    if (oldEntity != null)
                    {
                        _context.Entry(oldEntity).State = EntityState.Modified;
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rollback Error: {ex.Message}");
                return false;
            }
        }
    }
}


