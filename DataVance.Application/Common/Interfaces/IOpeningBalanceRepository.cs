using DataVance.Domain.Finance.OpeningBalances.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IOpeningBalanceRepository
    {
        Task<IEnumerable<OpeningBalance>> GetUnpostedBalancesAsync(Guid branchId, CancellationToken ct = default);
        Task<OpeningBalance?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(OpeningBalance openingBalance, CancellationToken ct = default);

    }

}


