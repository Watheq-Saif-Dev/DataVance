using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.AccountResolvers;
using DataVance.Application.Features.RuleEngine.AmountResolvers;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Application.Features.RuleEngine.RuleProviders;
using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Common.Models;


namespace DataVance.Application.Features.RuleEngine.JournalBuilders
{
    public class PostingJournal
    {
        private readonly RuleProvider _ruleProvider;
        private readonly AccountResolver _accountResolver;
        private readonly AmountResolver _amountResolver;
        private readonly JournalBuilder _journalBuilder;
        private readonly IApplicationDbContext _context;

        public PostingJournal(RuleProvider ruleProvider, AccountResolver accountResolver,
            AmountResolver amountResolver, JournalBuilder journalBuilder, IApplicationDbContext context)
        {
            _ruleProvider = ruleProvider;
            _accountResolver = accountResolver;
            _amountResolver = amountResolver;
            _journalBuilder = journalBuilder;
            _context = context;
        }

        public async Task<Result<JournalEntry>> PostAsync(PostingContext context, CancellationToken ct)
        {
            var journalResult = await BuildJournalAsync(context, ct);
            if (!journalResult.Succeeded || journalResult.Value == null)
                return journalResult;

            await _context.JournalEntries.AddAsync(journalResult.Value, ct);
            return Result<JournalEntry>.Success(journalResult.Value);
        }

        public async Task<Result<JournalEntry>> SimulatePostAsync(PostingContext context, CancellationToken ct)
        {
            // محاكاة عملية الترحيل (Dry Run) بدون التأثير على قاعدة البيانات
            var journalResult = await BuildJournalAsync(context, ct);
            if (!journalResult.Succeeded || journalResult.Value == null)
                return journalResult;
            
            try 
            {
                // التحقق النهائي من توازن القيد الناتج (Golden Balance Check)
                journalResult.Value.ValidateBalance();
            }
            catch (Exception ex)
            {
                return Result<JournalEntry>.Failure($"Validation failed: {ex.Message}");
            }
            
            return Result<JournalEntry>.Success(journalResult.Value);
        }

        private async Task<Result<JournalEntry>> BuildJournalAsync(PostingContext context, CancellationToken ct)
        {
            var rule = await _ruleProvider.GetRuleAsync(context.OperationCode, context.Date, ct);
            if (rule == null)
                return Result<JournalEntry>.Failure($"No active accounting rule found for operation: {context.OperationCode}");

            var journal = await _journalBuilder.BuildAsync(rule, context, _accountResolver, _amountResolver, ct);
            
            if (context.Note != null)
                journal.UpdateDescription(context.Note);

            return Result<JournalEntry>.Success(journal);
        }
    }
}


