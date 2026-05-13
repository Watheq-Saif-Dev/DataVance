using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Common.Models;
using DataVance.Domain.Finance.Rules.Enums;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Finance.Shared.Enums;
using DataVance.Application.Features.RuleEngine.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.ContextBuilders.Accounting
{
    public class FiscalClosingContextBuilder : IPostingContextBuilder
    {
        private readonly IApplicationDbContext _context;
        private readonly IAccountBalanceRepository _balanceRepo;

        public FiscalClosingContextBuilder(IApplicationDbContext context, IAccountBalanceRepository balanceRepo)
        {
            _context = context;
            _balanceRepo = balanceRepo;
        }

        public string OperationCode => "ACC_CLOSE";

        public async Task<Result<PostingContext>> BuildAsync(Guid referenceId, Guid branchId, CancellationToken ct)
        {
            // 1. التحقق من وجود الفترة/السنة وصحة الحالة
            var fiscalYear = await _context.FiscalYears
                .Include(y => y.Periods)
                .FirstOrDefaultAsync(y => y.Id == referenceId, ct);

            if (fiscalYear == null)
                return Result<PostingContext>.Failure($"Fiscal Year not found: {referenceId}");

            if (fiscalYear.IsClosed)
                return Result<PostingContext>.Failure("This fiscal year is already closed.");

            // 2. حارس الأمان (Guard): منع الإغلاق في حال وجود قيود غير مرحلة
            var unpostedSpec = new UnpostedJournalEntriesSpec(referenceId, branchId);
            var unpostedEntriesCount = await _context.JournalEntries
                .CountAsync(unpostedSpec.ToExpression(), ct);

            if (unpostedEntriesCount > 0)
                return Result<PostingContext>.Failure($"Cannot close: There are {unpostedEntriesCount} unposted journal entries for this branch in this year.");

            // 3. جمع أرصدة الحسابات المؤقتة (الإيرادات والمصاريف)
            var balances = await _balanceRepo.GetIncomeStatementBalancesAsync(branchId, referenceId);
            if (!balances.Any())
                return Result<PostingContext>.Failure("No balances found to close for this period.");

            var context = new PostingContext
            {
                OperationCode = OperationCode,
                DocumentId = fiscalYear.Id,
                Date = fiscalYear.EndDate,
                BranchId = branchId,
                Note = $"Closing Journal Entry for Fiscal Year: {fiscalYear.Name}",
                CurrencyContext = new OperationContext(Guid.Empty,1m,"base")
            };

            // 4. تطبيق المنطق الذهبي وتمرير الأرصدة كـ Dynamic Amounts
            decimal netIncome = 0;
            decimal totalRevenue = 0;
            decimal totalExpenses = 0;

            foreach (var bal in balances)
            {
                // نمرر رصيد كل حساب لإقفاله
                // الدقة المالية 0.0001m (المنطق الذهبي)
                var roundedBalance = Math.Round(bal.NetBalance, 4, MidpointRounding.AwayFromZero);
                
                if (roundedBalance == 0) continue;

                context.AddDynamicAmount(bal.AccountId, roundedBalance);
                context.AddReference(AccountSourceType.FinancialAccount, bal.AccountId);
                
                // حساب صافي الربح (الإيرادات - المصاريف)
                // الإيرادات عادة دائنة (سالبة في ميزان المراجعة إذا كان مدين - دائن)
                // المصاريف عادة مدينة (موجبة)
                // حسب الـ SQL: DebitTotal - CreditTotal
                // إذن: المصاريف موجبة، الإيرادات سالبة.
                if (bal.Type == AccountType.Revenue) 
                    totalRevenue += Math.Abs(roundedBalance);
                else 
                    totalExpenses += Math.Abs(roundedBalance);

                netIncome -= roundedBalance; // عكس الرصيد لإقفاله (إذا كان -500 إيراد، نحتاج +500 مدين لإقفاله)
            }

            // 5. حارس توازن الأرباح والخسائر (P&L Balance Guard)
            // التحقق من أن مجموع (الإيرادات - المصاريف) يطابق صافي الربح
            var calculatedNetIncome = totalRevenue - totalExpenses;
            if (Math.Abs(calculatedNetIncome - netIncome) > 0.0001m)
                 return Result<PostingContext>.Failure("P&L Guard Failure: Revenue - Expenses does not match the calculated Net Income.");

            // إضافة صافي الربح كمبلغ أساسي ليستخدمه الـ Rule في حساب الأرباح المبقاة
            context.AddAmount(AmountSourceType.NetAmount, netIncome);

            return Result<PostingContext>.Success(context);
        }
    }
}

