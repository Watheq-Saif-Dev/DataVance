using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.AccountingClosing.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{

    public class FiscalYearRepository : IFiscalYearRepository
    {
        private readonly IApplicationDbContext _context;
        public FiscalYearRepository(IApplicationDbContext context) => _context = context;

        public async Task<bool> IsOverlappingAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.FiscalYears.AnyAsync(f =>
                (startDate >= f.StartDate && startDate <= f.EndDate) ||
                (endDate >= f.StartDate && endDate <= f.EndDate));
        }
        public async Task AddAsync(FiscalYear fiscalYear)
        {
            await _context.FiscalYears.AddAsync(fiscalYear);
        }
        //public async Task<FiscalYear?> GetByIdAsync(Guid id) => await _context.FiscalYears.FindAsync(id);
        public async Task<FiscalYear?> GetByIdAsync(Guid id)
        {
            return await _context.FiscalYears
                .Include(f => f.Periods)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<FiscalYear?> GetActiveYearAsync()
        {
            return await _context.FiscalYears
                .Include(f => f.Periods)
                .FirstOrDefaultAsync(f => f.IsActive && !f.IsClosed);
        }
        public async Task UpdateAsync(FiscalYear fiscalYear)
        {
            _context.FiscalYears.Update(fiscalYear);
            await Task.CompletedTask;
        }
    }
}
