using DataVance.Application.Common;
using DataVance.Domain.Finance.Currencies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<Currency?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> IsCodeUniqueAsync(string code, CancellationToken cancellationToken = default);
        Task AddAsync(Currency currency, CancellationToken cancellationToken = default);
        void Update(Currency currency);
        Task<bool> AnyBaseCurrencyExistsAsync(CancellationToken cancellationToken = default);
    }
}

