using DataVance.Application.Common;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Events;
using DataVance.Domain.Common;
using DataVance.Domain.Entities.AuditSystem;
using DataVance.Domain.Entities.BranchSystem;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Domain.Entities.SecuritySystem;
using DataVance.Domain.Entities.TaxSystem;
using DataVance.Domain.Entities.UserSystem;
using DataVance.Domain.Finance.AccountingClosing.Entities;
using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Currencies.Entities;
using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Finance.Journal.Event;
using DataVance.Domain.Finance.OpeningBalances.Entities;
using DataVance.Domain.Finance.PaymentMethods;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.ItemSystem.Enums;
using DataVance.Domain.ItemSystem.Entities;
using DataVance.Domain.ItemSystem.ValueObjects;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Settings;
using DataVance.Domain.WarehouseSystem;
using DataVance.Domain.Warehousing.Inventory;
using DataVance.Domain.Warehousing.Movements.PurchaseSystem;
using DataVance.Domain.Warehousing.Setup.Entities;
using DataVance.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text.Json;


namespace DataVance.Infrastructure.Persistence
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>, IApplicationDbContext
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserContext _user;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator, ICurrentUserContext user) : base(options)
        {
            _mediator = mediator;
            _user = user;
        }
        public Guid CurrentBranchId => _user.BranchId;


        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<UserBranch> UserBranches => Set<UserBranch>();
        public DbSet<UserWarehouse> UserWarehouses => Set<UserWarehouse>();
        public DbSet<SystemPage> SystemPages { get; set; }
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<SystemAction> SystemActions => Set<SystemAction>();
        public DbSet<SystemEvent> SystemEvents => Set<SystemEvent>();
        public DbSet<EventTrigger> EventTriggers => Set<EventTrigger>();
        public DbSet<EventPermission> EventPermissions => Set<EventPermission>();
        public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

        //Finance
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<AccountBalance> AccountBalances => Set<AccountBalance>();
        public DbSet<FinancialAccount> FinancialAccounts => Set<FinancialAccount>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();
        public DbSet<FiscalPeriod> FiscalPeriods => Set<FiscalPeriod>();
        public DbSet<FiscalYear> FiscalYears => Set<FiscalYear>();
        public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
        public DbSet<JournalEntryLine> JournalEntryLines => Set<JournalEntryLine>();
        public DbSet<AccountAllowedCurrency> AccountAllowedCurrencies => Set<AccountAllowedCurrency>();

        //SystemSetting
        public DbSet<SystemSetting> SystemSettings => Set<SystemSetting>();

        //accunt rule
        public DbSet<AccountingOperation> AccountingOperations => Set<AccountingOperation>();
        public DbSet<AccountingRuleLine> AccountingRuleLines => Set<AccountingRuleLine>();
        public DbSet<AccountingRule> AccountingRules => Set<AccountingRule>();
        public DbSet<OpeningBalance> OpeningBalances => Set<OpeningBalance>();
        public DbSet<OpeningBalanceLine> OpeningBalanceLine => Set<OpeningBalanceLine>();
        public DbSet<AccountMapping> AccountMappings => Set<AccountMapping>();


        //item 
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemGroup> ItemGroups => Set<ItemGroup>();
        public DbSet<ItemUnit> ItemUnits => Set<ItemUnit>();
        public DbSet<ItemPrice> ItemPrices => Set<ItemPrice>();


        //
        public DbSet<GlobalUnit> GlobalUnits => Set<GlobalUnit>();
        public DbSet<UnitCategory> UnitCategories => Set<UnitCategory>();

        public DbSet<InventoryBalance> InventoryBalances => Set<InventoryBalance>();
        public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();


        public DbSet<PurchaseReceipt> PurchaseReceipts => Set<PurchaseReceipt>();
        public DbSet<PurchaseReceiptLine> PurchaseReceiptLines => Set<PurchaseReceiptLine>();
        public DbSet<Vendor> Vendors => Set<Vendor>();

        //Tax
        public DbSet<TaxAuthority> TaxAuthorities => Set<TaxAuthority>();
        public DbSet<TaxCode> TaxCodes => Set<TaxCode>();
        public DbSet<TaxRate> TaxRates => Set<TaxRate>();
        public DbSet<TaxType> TaxTypes => Set<TaxType>();
        public DbSet<ItemTax> ItemTaxes => Set<ItemTax>();
        public DbSet<LinkTax> LinkTaxes => Set<LinkTax>();
        public DbSet<PageAction> PageActions => Set<PageAction>();




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(IBranchEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(DbContextExtensions)
                        .GetMethod(nameof(DbContextExtensions.SetBranchFilter))
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { builder, this });
                }
            }
            builder.Entity<PurchaseReceiptLine>()
                         .HasOne(x => x.Item)
                         .WithMany() // أو .WithMany(i => i.PurchaseLines) إذا كان لديك قائمة في الـ Item
                         .HasForeignKey(x => x.ItemId)
                         .OnDelete(DeleteBehavior.Restrict); // منع حذف صنف له حركات


            builder.Entity<Account>().HasIndex(x => x.Code).IsUnique();
            builder.Entity<PurchaseReceipt>()
                     .OwnsOne(p => p.Payment); //دمجها مره وحده

            builder.Entity<PurchaseReceipt>(entity =>
            {
                entity.HasKey(x => x.Id);

                // إعداد الـ Context كـ Owned Entity
                entity.OwnsOne(x => x.Context, cb =>
                {
                    // يمكنك تخصيص أسماء الأعمدة في قاعدة البيانات لتبدو منظمة
                    //cb.Property(c => c.BranchId).HasColumnName("BranchId");
                    cb.Property(c => c.CurrencyId).HasColumnName("CurrencyId");
                    cb.Property(c => c.ExchangeRate).HasColumnName("ExchangeRate");
                    cb.Property(c => c.CurrencyCode).HasColumnName("CurrencyCode");
                });
            });

            builder.Entity<UserBranch>(entity =>
            {
                entity.HasKey(ub => new { ub.UserId, ub.BranchId }); // مفتاح مركب

                entity.HasOne(ub => ub.Branch)
                          .WithMany()
                          .HasForeignKey(ub => ub.BranchId)
                          .OnDelete(DeleteBehavior.Restrict);
            });

            // علاقة المستخدم بالمخزن (Many-to-Many)
            builder.Entity<UserWarehouse>(entity =>
            {
                entity.HasKey(uw => new { uw.UserId, uw.WarehouseId });

                entity.HasOne(uw => uw.Warehouse)
                      .WithMany()
                      .HasForeignKey(uw => uw.WarehouseId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<InventoryBalance>()
        .HasIndex(i => new { i.ItemId, i.WarehouseId, i.BatchNumber })
        .IsUnique();

            // ضمان عدم تكرار باركود الوحدة
            builder.Entity<ItemUnit>()
                .HasIndex(u => u.Barcode)
                .IsUnique()
                .HasFilter("[Barcode] IS NOT NULL");


            // إضافة التوقيت الزمني للحماية من التعديل المتزامن
            builder.Entity<InventoryBalance>()
                .Property(b => b.RowVersion)
                .IsRowVersion();



            var adminRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = adminRoleId,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                }
            );

            foreach (var property in builder.Model.GetEntityTypes()
          .SelectMany(t => t.GetProperties())
          .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                // المنطق الذهبي: 18 رقم إجمالي، 4 خانات بعد الفاصلة (0.0001m)
                property.SetPrecision(18);
                property.SetScale(4);
            }
            builder.Entity<Vendor>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.VendorCode).IsUnique();
                b.Property(x => x.Name).IsRequired().HasMaxLength(200);
            });


            builder.Entity<CategoryTax>(b =>
            {
                // 1. المفتاح المركب (CategoryId + TaxCodeId)
                b.HasKey(ct => new { ct.ItemGroupId, ct.TaxCodeId });

                // 2. إخبار قاعدة البيانات أن TaxCodeId هو Foreign Key يشير لجدول TaxCodes
                b.HasOne<TaxCode>()
                 .WithMany()
                 .HasForeignKey(ct => ct.TaxCodeId)
                 .OnDelete(DeleteBehavior.Restrict);
                // لا نريد حذف الفئة إذا تم حذف الضريبة، بل يفضل المنع.
            });

            builder.Entity<ItemTax>(b =>
            {
                // 1. المفتاح المركب (CategoryId + TaxCodeId)
                b.HasKey(ct => new { ct.ItemId, ct.TaxCodeId });

                // 2. إخبار قاعدة البيانات أن TaxCodeId هو Foreign Key يشير لجدول TaxCodes
                b.HasOne<TaxCode>()
                 .WithMany()
                 .HasForeignKey(ct => ct.TaxCodeId)
                 .OnDelete(DeleteBehavior.Restrict);
                // لا نريد حذف الفئة إذا تم حذف الضريبة، بل يفضل المنع.
            });
            builder.Entity<ItemGroup>(b =>
            {
                b.HasKey(c => c.Id);

                // 1. ربط الفئة بضرائبها
                b.HasMany(c => c.Taxes)
                 .WithOne() // الفئة تمتلك العديد من CategoryTax، وكل CategoryTax يعود لفئة واحدة
                 .HasForeignKey(ct => ct.ItemGroupId)
                 .OnDelete(DeleteBehavior.Cascade);
                // Cascade يعني: إذا حذفت الفئة (Category)، احذف فوراً كل ارتباطاتها بالضرائب من جدول CategoryTax

                // 2. إخبار EF Core باستخدام الحقل الخاص (_taxes) خلف الكواليس
                var taxesNavigation = b.Metadata.FindNavigation(nameof(ItemGroup.Taxes));
                taxesNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
            });
            builder.Entity<JournalEntryLine>(entity =>
            {
                entity.OwnsOne(x => x.TransactionDebit);
                entity.OwnsOne(x => x.TransactionCredit);
                entity.OwnsOne(x => x.BaseDebit);
                entity.OwnsOne(x => x.BaseCredit);
            });

            builder.Entity<AccountBalance>(entity =>
            {
                entity.HasKey(ab => new { ab.AccountId, ab.FiscalPeriodId }); // تعديل المفتاح إذا لزم الأمر
                entity.OwnsOne(x => x.Debit);
                entity.OwnsOne(x => x.Credit);
                entity.OwnsOne(x => x.LocalDebit);
                entity.OwnsOne(x => x.LocalCredit);
            });

            builder.Entity<OpeningBalanceLine>(entity =>
            {
                entity.OwnsOne(x => x.Debit);
                entity.OwnsOne(x => x.Credit);
            });

            builder.Ignore<JournalPostedEvent>();


        }


        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            while (true)
            {
                var domainEntities = ChangeTracker.Entries<AggregateRoot>()
                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                    .ToList();

                if (!domainEntities.Any()) break;

                var events = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();

                foreach (var entity in domainEntities)
                    entity.Entity.ClearDomainEvents();

                foreach (var @event in events)
                {
                    if (@event is ISyncDomainEvent syncEvent)
                    {
                        var notificationType = typeof(DomainEventNotification<>).MakeGenericType(syncEvent.GetType());
                        var notification = Activator.CreateInstance(notificationType, syncEvent);

                        // تأكد أن الـ Handlers هنا يضيفون الكائنات للـ Tracker فقط
                        await _mediator.Publish(notification!, ct);
                    }
                    else if (@event is IAsyncDomainEvent asyncEvent)
                    {
                        SaveToOutbox(asyncEvent);
                    }
                }
            }

            // نقل هذا الجزء ليكون قبل الـ Save النهائي مباشرة لضمان شمول القيود المحاسبية المنشأة حديثاً
            var addedEntities = ChangeTracker.Entries<IBranchEntity>()
                .Where(x => x.State == EntityState.Added);

            foreach (var entry in addedEntities)
            {
                if (entry.Entity.BranchId == Guid.Empty)
                {
                    entry.Entity.SetBranchId(_user.BranchId);
                }
            }

            // نصيحة: أضف Log هنا للتأكد من عدد الكائنات المنتظرة للحفظ
            var count = ChangeTracker.Entries().Count(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            //_logger.LogInformation("? Saving {Count} changes to database...", count);

            return await base.SaveChangesAsync(ct);
        }



        // الدالة الخاصة بحفظ الأوت بوكس
        private void SaveToOutbox(IAsyncDomainEvent asyncEvent)
        {
            var eventJson = JsonSerializer.Serialize(asyncEvent, asyncEvent.GetType(), _jsonOptions);

            var outboxMessage = new OutboxMessage(
                type: asyncEvent.GetType().Name,
                content: eventJson,
                targetType: OutboxTargetType.Event,
                userId: _user.UserId,
                userEmail: _user.UserName,
                isFromDomain: true // علامة لتحديد أن هذا الحدث جاء من الدومين وليس من عملية خارجية
            );

            // إضافة الرسالة إلى جدول الأوت بوكس في نفس الـ DbContext
            this.OutboxMessages.Add(outboxMessage);
        }
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IncludeFields = true
        };


    }
}

