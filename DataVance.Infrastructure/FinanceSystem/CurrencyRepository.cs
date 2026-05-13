using DataVance.Application.Common;
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
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Currency?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Currency>()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
        public async Task<bool> IsCodeUniqueAsync(string code, CancellationToken cancellationToken = default)
        {
            // نتحقق من عدم وجود عملة بنفس الكود (مع تجاهل حالة الأحرف)
            return !await _context.Set<Currency>()
                .AnyAsync(c => c.Code.ToLower() == code.ToLower(), cancellationToken);
        }

        public async Task AddAsync(Currency currency, CancellationToken cancellationToken = default)
        {
            await _context.Set<Currency>().AddAsync(currency, cancellationToken);
        }
        public void Update(Currency currency)
        {
            _context.Set<Currency>().Update(currency);
        }

        public async Task<bool> AnyBaseCurrencyExistsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Currency>()
                .AnyAsync(c => c.IsBaseCurrency, cancellationToken);
        }
    }
}
