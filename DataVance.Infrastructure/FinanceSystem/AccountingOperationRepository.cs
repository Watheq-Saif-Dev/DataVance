using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class AccountingOperationRepository : IAccountingOperationRepository
    {
        private readonly IApplicationDbContext _context;

        public AccountingOperationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccountingOperation?> GetByCodeAsync(string code, CancellationToken ct = default)
        {
            return await _context.AccountingOperations
                .FirstOrDefaultAsync(x => x.Code == code, ct);
        }

        public async Task<AccountingOperation?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.AccountingOperations.FindAsync(new object[] { id }, ct);
        }

        public async Task<IEnumerable<AccountingOperation>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.AccountingOperations.ToListAsync(ct);
        }
    }
}
