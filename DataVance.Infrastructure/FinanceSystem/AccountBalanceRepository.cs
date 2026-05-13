using Dapper;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Accounting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataVance.Application.Common.Interfaces.IAccountBalanceRepository;

namespace DataVance.Infrastructure.FinanceٌRepository
{
    public class AccountBalanceRepository : IAccountBalanceRepository
    {
        //private readonly IDbConnection _dbConnection;

        //public AccountBalanceRepository(IDbConnection dbConnection) => _dbConnection = dbConnection;
        private readonly IApplicationDbContext _context;
        private readonly IDbConnection _dbConnection;

        public AccountBalanceRepository(IApplicationDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _dbConnection = dbConnection;
        }
        public async Task<AccountBalance?> GetAsync(Guid accountId, Guid branchId, Guid periodId)
        {
            return await _context.AccountBalances
                .FirstOrDefaultAsync(x => x.AccountId == accountId && x.BranchId == branchId && x.FiscalPeriodId == periodId);
        }
        public async Task<AccountBalance?> GetBalanceAsync(Guid accountId, Guid branchId, Guid periodId, Guid currencyId)
        {
            return await _context.AccountBalances
                .FirstOrDefaultAsync(b =>
                    b.AccountId == accountId &&
                    b.BranchId == branchId &&
                    b.FiscalPeriodId == periodId &&
                    b.Debit.CurrencyId == currencyId);
        }

        public async Task AddAsync(AccountBalance balance) => await _context.AccountBalances.AddAsync(balance);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<List<AccountClosingDto>> GetIncomeStatementBalancesAsync(Guid branchId, Guid fiscalYearId)
        {
            // استعلام لجلب صافي الأرصدة للحسابات من نوع (إيراد = 4) و (مصروفات = 5)
            const string sql = @"
            SELECT 
                b.AccountId, 
                SUM(b.Debit_Amount - b.Credit_Amount) as NetBalance,
                a.Type 
            FROM AccountBalances b
            INNER JOIN Accounts a ON b.AccountId = a.Id
            INNER JOIN FiscalPeriods p ON b.FiscalPeriodId = p.Id WHERE b.BranchId = @BranchId AND p.FiscalYearId = @FiscalYearId
            AND a.Type IN (4, 5) -- 4: Revenue, 5: Expenses
            GROUP BY b.AccountId, a.Type
            HAVING SUM(b.Debit_Amount - b.Credit_Amount) <> 0";

            var result = await _dbConnection.QueryAsync<AccountClosingDto>(sql, new { branchId, fiscalYearId });
            return result.ToList();
        }



    }
}


