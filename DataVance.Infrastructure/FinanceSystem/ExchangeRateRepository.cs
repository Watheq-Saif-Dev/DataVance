using DataVance.Domain.Finance.Currencies.Entities;
using DataVance.Application.Common.Interfaces;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ApplicationDbContext _context;

        public ExchangeRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExchangeRate exchangeRate, CancellationToken cancellationToken = default)
        {
            await _context.Set<ExchangeRate>().AddAsync(exchangeRate, cancellationToken);
            // ملاحظة: لا نستدعي SaveChanges هنا، الـ Unit of Work هو المسؤول
        }

        public async Task<ExchangeRate?> GetLatestRateAsync(Guid currencyId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<ExchangeRate>()
                .Where(r => r.CurrencyId == currencyId)
                .OrderByDescending(r => r.EffectiveDate)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<decimal?> GetRateAtDateAsync(Guid currencyId, DateTime date, CancellationToken cancellationToken = default)
        {
            // استعلام احترافي: جلب أقرب سعر صرف قبل أو في التاريخ المحدد
            return await _context.Set<ExchangeRate>()
                .Where(r => r.CurrencyId == currencyId && r.EffectiveDate <= date)
                .OrderByDescending(r => r.EffectiveDate)
                .Select(r => (decimal?)r.Rate)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
