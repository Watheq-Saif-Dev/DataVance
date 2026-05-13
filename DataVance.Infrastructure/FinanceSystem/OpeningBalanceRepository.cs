using DataVance.Domain.Finance.OpeningBalances.Entities;
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
    public class OpeningBalanceRepository : IOpeningBalanceRepository
    {
        private readonly ApplicationDbContext _context;

        public OpeningBalanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpeningBalance>> GetUnpostedBalancesAsync(Guid branchId, CancellationToken ct = default)
        {
            return await _context.OpeningBalances
                .Include(x => x.Lines)
                .Where(x => !x.IsPosted && x.BranchId == branchId)
                .AsNoTracking()
                .ToListAsync(ct);
        }
        public async Task<OpeningBalance?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.OpeningBalances
                .Include(x => x.Lines) // ضروري جداً لجلب أسطر الحسابات
                .FirstOrDefaultAsync(x => x.Id == id, ct);

        }

        public async Task AddAsync(OpeningBalance openingBalance, CancellationToken ct = default)
        {
            await _context.OpeningBalances.AddAsync(openingBalance, ct);
        }
    }
}

