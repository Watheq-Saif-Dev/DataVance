using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Finance.Rules.Events;

namespace DataVance.Application.Features.RuleEngine.AccountingRulesService
{
    /// <summary>
    /// Interface for the Accounting Rule Engine that processes domain events
    /// and generates journal entries based on accounting rules.
    /// </summary>
    public interface IAccountingRuleEngine
    {
        Task<JournalEntry> ProcessAsync(PostToAccountingEvent @event, CancellationToken ct);
    }
}

