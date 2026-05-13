using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Accounting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IApplicationDbContext _context;
        public AccountRepository(IApplicationDbContext context) => _context = context;

        public async Task<Account?> GetByIdAsync(Guid id)
            => await _context.Accounts.FindAsync(id);

        public async Task<bool> ExistsAsync(Guid id)
            => await _context.Accounts.AnyAsync(x => x.Id == id && x.IsActive);
    }
}

