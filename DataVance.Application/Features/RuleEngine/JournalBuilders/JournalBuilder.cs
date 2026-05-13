using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.AccountResolvers;
using DataVance.Application.Features.RuleEngine.AmountResolvers;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Finance.Rules.Enums;

namespace DataVance.Application.Features.RuleEngine.JournalBuilders
{
    public class JournalBuilder
    {
        private readonly IFiscalYearRepository _fiscalYear;
        private readonly IFiscalPeriodRepository _fiscalPeriod;
        private readonly IJournalNumberGenerator _journalNumber;

        public JournalBuilder(IFiscalYearRepository fiscalYear, IFiscalPeriodRepository fiscalPeriod, IJournalNumberGenerator journalNumber)
        {
            _fiscalYear = fiscalYear;
            _fiscalPeriod = fiscalPeriod;
            _journalNumber = journalNumber;
        }

        public async Task<JournalEntry> BuildAsync(
                            AccountingRule rule,
                            PostingContext context,
                            AccountResolver accountResolver,
                            AmountResolver amountResolver,
                            CancellationToken ct)
        {
            var fiscalYear = await _fiscalYear.GetActiveYearAsync();
            if (fiscalYear == null || fiscalYear.IsClosed)
                throw new InvalidOperationException("ط§ظ„ظپطھط±ط© ط§ظ„ظ…ط§ظ„ظٹط© ط؛ظٹط± ظ…ظˆط¬ظˆط¯ط© ط£ظˆ ظ…ط؛ظ„ظ‚ط©.");

            var fiscalPeriod = await _fiscalPeriod.GetPeriodByDateAsync(context.Date);
            if (fiscalPeriod == null || fiscalPeriod.IsClosed)
                throw new InvalidOperationException("ط§ظ„ظپطھط±ط© ط§ظ„ظ…ط­ط§ط³ط¨ظٹط© ط؛ظٹط± ظ…ظˆط¬ظˆط¯ط© ط£ظˆ ظ…ط؛ظ„ظ‚ط©.");


            var journal = new JournalEntry(
                    entryNumber: await _journalNumber.GenerateNextNumberAsync(ct),
                    date: context.Date,
                    branchId: context.BranchId,
                    fiscalYearId: fiscalYear.Id,
                    fiscalPeriodId: fiscalPeriod.Id,
                    currencyId: context.CurrencyContext.CurrencyId,
                    currencyCode: context.CurrencyContext.CurrencyCode,
                    exchangeRate: context.CurrencyContext.ExchangeRate
                );


            var orderedLines = rule.Lines.OrderBy(l => l.Order).ToList();

            foreach (var ruleLine in orderedLines)
            {

                if (ruleLine.AmountSourceType == AmountSourceType.TaxAmount)

                {
                    await ProcessTaxes(ruleLine, context, amountResolver, accountResolver, journal);
                    continue;
                }

                decimal originalAmount = amountResolver.ResolveAmount(ruleLine, context);
                if (originalAmount == 0) continue;

                var accountId = await accountResolver.ResolveAccount(context, ruleLine);

                AddJournalLine(journal, ruleLine, context, originalAmount, accountId);
            }

            journal.ValidateBalance();
            return journal;
        }

        private async Task ProcessTaxes(
            AccountingRuleLine ruleLine,
            PostingContext context,
            AmountResolver amountResolver,
            AccountResolver accountResolver,
            JournalEntry journal)
        {

            foreach (var tax in context.Taxes)
            {
                var accountId = await accountResolver.ResolveAccount(context, ruleLine, tax.TaxCode);

                var amount = amountResolver.ResolveAmount(ruleLine, context, tax.TaxCode);
                if (amount > 0)
                {
                    AddJournalLine(journal, ruleLine, context, amount, accountId);
                }
            }
        }
        private void AddJournalLine(
                                   JournalEntry journal,
                                   AccountingRuleLine ruleLine,
                                   PostingContext context,
                                   decimal amount,
                                   Guid accountId)
        {
            if (amount == 0) return;

            decimal debit = ruleLine.EntrySide == EntrySide.Debit ? amount : 0;
            decimal credit = ruleLine.EntrySide == EntrySide.Credit ? amount : 0;

            journal.AddLine(
                accountId: accountId,
                debit: debit,
                credit: credit,
                costCenterId: null,
                currencyId: context.CurrencyContext.CurrencyId,
                exchangeRate: journal.ExchangeRate
            );
        }

    }
}

