using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IAccountBalanceRepository
    {
        Task<List<AccountClosingDto>> GetIncomeStatementBalancesAsync(Guid branchId, Guid fiscalYearId);
        public record AccountClosingDto(Guid AccountId, decimal NetBalance, AccountType Type);
        Task<AccountBalance?> GetAsync(Guid accountId, Guid branchId, Guid periodId);
        Task AddAsync(AccountBalance balance);
        Task SaveChangesAsync();
        Task<AccountBalance?> GetBalanceAsync(Guid accountId, Guid branchId, Guid periodId, Guid currencyId);
    }

}


