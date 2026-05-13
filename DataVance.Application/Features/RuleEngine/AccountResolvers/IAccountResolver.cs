using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Finance.PaymentMethods;
using DataVance.Domain.Finance.Rules.Enums;

namespace DataVance.Application.Features.RuleEngine.AccountResolvers
{
    public interface IAccountResolver
    {
        bool IsMatch(AccountSourceType account, PaymentMethodType paymentMethod);
        Task<Guid> ResolveAccount(PostingContext context, IAccountMappingResolver mappingRepo, Guid? currentReferenceId = null);
    }
}


