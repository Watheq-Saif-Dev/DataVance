using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Rules.Entities;
namespace DataVance.Application.Features.RuleEngine.RuleProviders
{
    public class RuleProvider
    {
        private readonly IAccountingRuleRepository _ruleRepo;

        public RuleProvider(IAccountingRuleRepository ruleRepo)
        {
            _ruleRepo = ruleRepo;
        }

        public async Task<AccountingRule> GetRuleAsync(string operationCode, DateTime date, CancellationToken ct)
        {
            var rule = await _ruleRepo.GetActiveRuleAsync(operationCode, date, ct);
            if (rule == null)
                throw new Exception($"ظ„ط§ طھظˆط¬ط¯ ظ‚ط§ط¹ط¯ط© ظ…ط­ط§ط³ط¨ظٹط© ظ„ظ„ط¹ظ…ظ„ظٹط© {operationCode}");
            return rule;
        }
    }
}

