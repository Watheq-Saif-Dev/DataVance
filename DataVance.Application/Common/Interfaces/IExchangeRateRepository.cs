using DataVance.Domain.Finance.Currencies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task AddAsync(ExchangeRate exchangeRate, CancellationToken cancellationToken = default);
        Task<ExchangeRate?> GetLatestRateAsync(Guid currencyId, CancellationToken cancellationToken = default);
        Task<decimal?> GetRateAtDateAsync(Guid currencyId, DateTime date, CancellationToken cancellationToken = default);
    }
}

