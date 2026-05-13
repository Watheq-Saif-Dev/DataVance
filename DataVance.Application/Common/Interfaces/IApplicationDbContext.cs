using DataVance.Application.DTOs;
using DataVance.Domain.Common;
using DataVance.Domain.Entities.AuditSystem;
using DataVance.Domain.Entities.BranchSystem;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Domain.Entities.SecuritySystem;
using DataVance.Domain.Entities.UserSystem;
using DataVance.Domain.Finance.AccountingClosing.Entities;
using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Currencies.Entities;
using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Settings;
using DataVance.Domain.Warehousing.Movements.PurchaseSystem;
using DataVance.Domain.Warehousing.Setup.Entities;
using DataVance.Domain.Finance.OpeningBalances.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace DataVance.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; }
        EntityEntry Attach(object entity);
        EntityEntry Entry(object entity);
        DbSet<IdentityUserRole<Guid>> UserRoles { get; }
        DbSet<IdentityRole<Guid>> Roles { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<SystemPage> SystemPages { get; }
        DbSet<Permission> Permissions { get; }
        DbSet<Branch> Branches { get; }
        DbSet<Warehouse> Warehouses { get; }
        DbSet<UserBranch> UserBranches { get; }
        DbSet<UserWarehouse> UserWarehouses { get; }
        DbSet<AuditLog> AuditLogs { get; }
        DbSet<SystemAction> SystemActions { get; }
        DbSet<PageAction> PageActions { get; }

        DbSet<SystemEvent> SystemEvents { get; }
        DbSet<EventTrigger> EventTriggers { get; }
        DbSet<EventPermission> EventPermissions { get; }
        EntityEntry Remove(object entity);
        DbSet<OutboxMessage> OutboxMessages { get; }
        ChangeTracker ChangeTracker { get; }
        DbSet<Account> Accounts { get; }
        DbSet<AccountBalance> AccountBalances { get; }
        DbSet<Currency> Currencies { get; }
        DbSet<ExchangeRate> ExchangeRates { get; }
        DbSet<FiscalPeriod> FiscalPeriods { get; }
        DbSet<FiscalYear> FiscalYears { get; }
        DbSet<JournalEntry> JournalEntries { get; }
        DbSet<JournalEntryLine> JournalEntryLines { get; }
        DbSet<SystemSetting> SystemSettings { get; }


        DbSet<PurchaseReceiptLine> PurchaseReceiptLines { get; }
        DbSet<PurchaseReceipt> PurchaseReceipts { get; }
        DbSet<AccountingRule> AccountingRules { get; }
        DbSet<AccountingOperation> AccountingOperations { get; }
        DbSet<AccountingRuleLine> AccountingRuleLines { get; }
        DbSet<AccountMapping> AccountMappings { get; }
        DbSet<OpeningBalance> OpeningBalances { get; }
        DbSet<OpeningBalanceLine> OpeningBalanceLine { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}


