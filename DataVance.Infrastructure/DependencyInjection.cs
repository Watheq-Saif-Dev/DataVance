using DataVance.Application.AlertServices;
using DataVance.Application.AuditSystem.Service;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.PurchaseTransactions.Service;
using DataVance.Application.Security.Service;
using DataVance.Application.SharedAgg.BrancheSystem.Service;
using DataVance.Application.SharedAgg.Setting.Interface;
using DataVance.Domain.Common;
using DataVance.Infrastructure.BranchRep;
using DataVance.Infrastructure.Common;
using DataVance.Infrastructure.FinanceSystem;

using DataVance.Infrastructure.Identity;
using DataVance.Infrastructure.ItemService;
using DataVance.Infrastructure.Persistence;
using DataVance.Infrastructure.Services;
using DataVance.Infrastructure.SettingSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace DataVance.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IDbConnection>(sp =>
            {
                var context = sp.GetRequiredService<ApplicationDbContext>();
                return context.Database.GetDbConnection();
            });

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IIdentityService, IdentityService>();
            // Modularized Services
            services.AddFinancialServices();
            services.AddEventSystemServices();

            services.AddScoped<ICurrentUserContext, CurrentUserContext>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<IStatusMessageService, StatusMessageService>();
            services.AddScoped<ISystemSettingsService, SystemSettingsService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ILookUpService, LookUpService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IAccountMappingResolver, AccountMappingResolver>();
            services.AddScoped<IPermissionService, PermissionService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
