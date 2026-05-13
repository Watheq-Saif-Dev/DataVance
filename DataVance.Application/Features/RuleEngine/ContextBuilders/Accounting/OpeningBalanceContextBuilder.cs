using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Common.Models;
using DataVance.Domain.Finance.OpeningBalances.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using DataVance.Domain.Finance.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.ContextBuilders.Accounting
{
    public class OpeningBalanceContextBuilder : IPostingContextBuilder
    {
        private readonly IApplicationDbContext _context;

        public OpeningBalanceContextBuilder(IApplicationDbContext context)
        {
            _context = context;
        }

        public string OperationCode => "ACC_OB";

        public async Task<Result<PostingContext>> BuildAsync(Guid referenceId, Guid branchId, CancellationToken ct)
        {
            var document = await _context.OpeningBalances
                .Include(x => x.Lines)
                .FirstOrDefaultAsync(x => x.Id == referenceId && x.BranchId == branchId, ct);

            if (document == null)
                return Result<PostingContext>.Failure($"Opening Balance document not found: {referenceId}");

            var context = new PostingContext
            {
                OperationCode = OperationCode,
                DocumentId = document.Id,
                Date = document.OpeningDate,
                BranchId = document.BranchId,
                CurrencyContext = new OperationContext(document.CurrencyId,document.ExchangeRate,document.CurrencyCode)
            };

            // تحويل أسطر الرصيد الافتتاحي إلى مبالغ ديناميكية يمكن للمحرك قراءتها
            // في حالة الأرصدة الافتتاحية، نحن نمرر الأسطر مباشرة كمبالغ مرتبطة بالحسابات
            foreach (var line in document.Lines)
            {
                // نستخدم الـ AccountId كـ Key للمبلغ لسهولة الوصول إليه في الـ Rule
                context.AddDynamicAmount(line.AccountId, line.Debit.Amount > 0 ? line.Debit.Amount : -line.Credit.Amount);
                context.AddReference(AccountSourceType.FinancialAccount, line.AccountId);
            }

            return Result<PostingContext>.Success(context);
        }
    }
}
