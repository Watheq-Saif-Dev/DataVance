using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.PurchaseTransactions.Service;
using DataVance.Infrastructure.FinanceٌRepository;
using DataVance.Infrastructure.FinanceSystem;
using DataVance.Infrastructure.ItemService;
using Microsoft.Extensions.DependencyInjection;

namespace DataVance.Infrastructure
{
    public static class FinancialServicesRegistration
    {
        public static IServiceCollection AddFinancialServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountBalanceRepository, AccountBalanceRepository>();
            services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();
            services.AddScoped<IFiscalYearRepository, FiscalYearRepository>();
            services.AddScoped<IFiscalPeriodRepository, FiscalPeriodRepository>();
            services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IOpeningBalanceRepository, OpeningBalanceRepository>();
            services.AddScoped<IAccountingOperationRepository, AccountingOperationRepository>();
            services.AddScoped<IAccountingRuleRepository, AccountingRuleRepository>();
            services.AddScoped<IPurchaseAccountingRepository, PurchaseAccountingRepository>();
            services.AddScoped<IJournalNumberGenerator, JournalNumberGenerator>();

            return services;
        }
    }
}
