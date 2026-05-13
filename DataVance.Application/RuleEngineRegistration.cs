using DataVance.Application.Features.RuleEngine.AccountResolvers;
using DataVance.Application.Features.RuleEngine.AmountResolvers;
using DataVance.Application.Features.RuleEngine.ContextBuilders.Accounting;
using DataVance.Application.Features.RuleEngine.ContextBuilders.Purchase;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Application.Features.RuleEngine.JournalBuilders;
using DataVance.Application.Features.RuleEngine.RuleProviders;
using Microsoft.Extensions.DependencyInjection;

namespace DataVance.Application
{
    public static class RuleEngineRegistration
    {
        public static IServiceCollection AddRuleEngineServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountResolver, CashAccountResolver>();
            services.AddScoped<IAccountResolver, PayableToAccountResolver>();
            services.AddScoped<IAccountResolver, PayableToCreditResolver>();
            services.AddScoped<IAccountResolver, InventoryAccountResolver>();
            
            services.AddScoped<RuleProvider>();
            services.AddScoped<AmountResolver>();
            services.AddScoped<AccountResolver>();
            services.AddScoped<JournalBuilder>();
            services.AddScoped<PostingContextFactory>();
            services.AddScoped<PostingJournal>();
            
            services.AddScoped<IPostingContextBuilder, PurchaseReceiptContextBuilder>();
            services.AddScoped<IPostingContextBuilder, OpeningBalanceContextBuilder>();
            services.AddScoped<IPostingContextBuilder, FiscalClosingContextBuilder>();

            return services;
        }
    }
}
