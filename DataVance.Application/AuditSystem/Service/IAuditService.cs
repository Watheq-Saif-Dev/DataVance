using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AuditSystem.Service
{
    public interface IAuditService
    {
        Task LogCreateAsync<TRequest, TEntity>(TRequest request, TEntity entity);
        Task LogUpdateAsync<TRequest, TEntity>(TRequest request, TEntity newEntity, TEntity oldEntity);
        Task LogAsync<TRequest, TEntity>(TRequest request, TEntity entity) where TEntity : class;
        Task LogIntentAsync<TRequest>(TRequest request, string action);
    }
}
