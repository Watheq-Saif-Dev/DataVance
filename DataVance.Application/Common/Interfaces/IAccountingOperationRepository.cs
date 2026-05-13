using DataVance.Domain.Finance.Rules.Entities;

namespace DataVance.Application.Common.Interfaces
{

    public interface IAccountingOperationRepository
    {
        Task<AccountingOperation?> GetByCodeAsync(string code, CancellationToken ct = default);
        Task<AccountingOperation?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<AccountingOperation>> GetAllAsync(CancellationToken ct = default);
    }
}

