using DataVance.Application.Features.RuleEngine.AccountingRulesService;
using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Finance.Rules.Events;

namespace DataVance.Application.Features.RuleEngine.AccountingRulesService
{
    /// <summary>
    /// Entry-point service that orchestrates the full accounting-posting pipeline.
    /// Delegates to PostingContextFactory → PostingJournal internally.
    /// </summary>
    public class AccountingRuleEngine : IAccountingRuleEngine
    {
        // TODO: inject PostingContextFactory + PostingJournal and delegate
        public Task<JournalEntry> ProcessAsync(PostToAccountingEvent @event, CancellationToken ct)
            => throw new NotImplementedException();
    }
}


