using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Common
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        // فحص هل يوجد ترانزكشن نشط حالياً؟
        bool HasActiveTransaction { get; }

        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollbackAsync(CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        // تعيد عدد السجلات المتأثرة
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        //// دوال إدارة التراسل (Transactions)
        //Task BeginTransactionAsync(IsolationLevel isolationLevel , CancellationToken ct = default);
        ////Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, Guid? branchId = null, CancellationToken ct = default);
        //Task CommitAsync(CancellationToken ct = default);
        //Task RollbackAsync(CancellationToken ct = default);
    }
}
