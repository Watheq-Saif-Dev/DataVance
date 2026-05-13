using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{

    public interface IAccountingRuleRepository
    {
        Task<AccountingRule?> GetEffectiveRuleAsync(Guid operationId, DateTime eventDate, CancellationToken ct = default);
        Task AddAsync(AccountingRule rule, CancellationToken ct = default);
        Task<IEnumerable<AccountingRule>> GetRulesByOperationIdAsync(Guid operationId, CancellationToken ct = default);

        Task<Guid> GetAccountIdAsync(
        AccountSourceType sourceType,
        MapPurpose purpose,
        Guid? referenceId,
        Guid? WarehouseId,
        CancellationToken ct = default);
        Task<AccountingRule> GetActiveRuleAsync(string operationCode, DateTime eventDate, CancellationToken ct);
    }
}



