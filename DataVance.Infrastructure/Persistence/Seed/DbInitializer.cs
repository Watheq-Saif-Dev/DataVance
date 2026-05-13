using DataVance.Application.Features.Warehouses.Commands;
using DataVance.Domain.Common;
using DataVance.Domain.Entities.BranchSystem;
using DataVance.Domain.Entities.Enums;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Domain.Entities.SecuritySystem;
using DataVance.Domain.Entities.UserSystem;
using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.PaymentMethods;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Finance.Shared.Enums;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using DataVance.Domain.Settings;
using DataVance.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Dapper.SqlMapper;
namespace DataVance.Infrastructure.Persistence.Seed
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            await context.Database.MigrateAsync();


            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("SuperAdmin"));

            }
            if (!await context.SystemActions.AnyAsync())
            {
                await context.SaveChangesAsync();
            }
            if (!await context.Branches.AnyAsync())
            {
            }

            var adminEmail = "admin@datavance.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "مدير النظام",
                    EmailConfirmed = true,
                    IsActive = true,

                };


                var result = await userManager.CreateAsync(adminUser, "DataVance@@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "SuperAdmin");


                    var Branch = await context.Branches.FirstAsync();

                    context.UserBranches.Add(new UserBranch { UserId = adminUser.Id, BranchId = Branch.Id });
                    await context.SaveChangesAsync();

                }
            }
            // 5️⃣ SystemEvents
            if (!await context.SystemEvents.AnyAsync())
            {
                var createWarehouseAudit = new SystemEvent("CreateWarehouseAudit", "Warehouse Creation Audit", "Warehouses");

                var sendWhatsAppEvent = new SystemEvent("SendWhatsAppOnCreate", "Send WhatsApp Notification", "Warehouses");

                context.SystemEvents.AddRange(createWarehouseAudit, sendWhatsAppEvent);
                await context.SaveChangesAsync();

                // 6️⃣ EventTriggers
                var triggers = new List<EventTrigger>
            {
                new EventTrigger("CreateWarehouseCommand",createWarehouseAudit.Id,1,EventImportance.Optional),

                new EventTrigger("CreateWarehouseCommand",sendWhatsAppEvent.Id ,2,EventImportance.Optional)

            };
                context.EventTriggers.AddRange(triggers);
                await context.SaveChangesAsync();

                // 7️⃣ EventPermissions (ربط المستخدم بالأحداث)
                var adminUserId = (await userManager.FindByEmailAsync(adminEmail))!.Id;
                var branchId = (await context.Branches.FirstAsync()).Id;

                var permissions = new List<EventPermission>
            {
               new  EventPermission(adminUserId,PermissionTarget.User ,createWarehouseAudit.Id,branchId ,null,true),

                new EventPermission(adminUserId,PermissionTarget.User ,createWarehouseAudit.Id,branchId ,null,true)

            };
                context.EventPermissions.AddRange(permissions);
                await context.SaveChangesAsync();
            }

            if (!await context.Accounts.AnyAsync())
            {

                // --- المستوى الأول (الحسابات الرئيسية) ---
                var assets = new Account("1", "الأصول", AccountType.Asset, null);
                assets.SetAsParent();

                var liabilities = new Account("2", "الالتزامات", AccountType.Liability, null);
                liabilities.SetAsParent();

                var equity = new Account("3", "حقوق الملكية", AccountType.Equity, null);
                equity.SetAsParent();

                var revenue = new Account("4", "الإيرادات", AccountType.Revenue, null);
                revenue.SetAsParent();

                var expenses = new Account("5", "المصروفات", AccountType.Expense, null);
                expenses.SetAsParent();

                context.Accounts.AddRange(assets, liabilities, equity, revenue, expenses);
                await context.SaveChangesAsync();

                // --- المستوى الثاني (الحسابات المساعدة) ---

                // تحت الأصول
                var currentAssets = new Account("11", "الأصول المتداولة", AccountType.Asset, assets.Id);
                currentAssets.SetAsParent();

                var fixedAssets = new Account("12", "الأصول الثابتة", AccountType.Asset, assets.Id);
                fixedAssets.SetAsParent();

                // تحت الالتزامات
                var currentLiabilities = new Account("21", "الالتزامات المتداولة", AccountType.Liability, liabilities.Id);
                currentLiabilities.SetAsParent();

                // تحت حقوق الملكية
                var capitalGroup = new Account("31", "رأس المال والاحتياطيات", AccountType.Equity, equity.Id);
                capitalGroup.SetAsParent();

                context.Accounts.AddRange(currentAssets, fixedAssets, currentLiabilities, capitalGroup);
                await context.SaveChangesAsync();

                // --- المستوى الثالث (الحسابات التحليلية - حسابات الحركة) ---
                // هذه الحسابات التي سيتم الترحيل عليها وتظهر في واجهة الأرصدة الافتتاحية

                var accountsToAdd = new List<Account>
    {
        // النقدية وما في حكمها (تحت الأصول المتداولة)
        new Account("1101001", "الصندوق الرئيسي", AccountType.Asset, currentAssets.Id),
        new Account("1101002", "صندوق العهد", AccountType.Asset, currentAssets.Id),
        new Account("1102001", "البنك - حساب محلي (ريال)", AccountType.Asset, currentAssets.Id),
        
        // ذمم مدينة
        new Account("1103001", "العملاء", AccountType.Asset, currentAssets.Id),
        
        // الأصول الثابتة (تحت الأصول الثابتة)
        new Account("1201001", "الأثاث والتجهيزات", AccountType.Asset, fixedAssets.Id),
        new Account("1201002", "أجهزة الحاسوب والشبكات", AccountType.Asset, fixedAssets.Id),

        // ذمم دائنة (تحت الالتزامات المتداولة)
        new Account("2101001", "الموردون", AccountType.Liability, currentLiabilities.Id),
        new Account("2102001", "مصاريف مستحقة", AccountType.Liability, currentLiabilities.Id),

        // حسابات الملكية (مهمة جداً للأرصدة الافتتاحية)
        new Account("3101001", "رأس المال", AccountType.Equity, capitalGroup.Id),
        new Account("3101002", "الأرباح المحتجزة", AccountType.Equity, capitalGroup.Id),
        new Account("3101003", "حساب تسوية الأرصدة الافتتاحية (وسيط)", AccountType.Equity, capitalGroup.Id),

        // المصروفات
        new Account("5001001", "رواتب وأجور", AccountType.Expense, expenses.Id),
        new Account("5001002", "إيجارات", AccountType.Expense, expenses.Id),
        new Account("5001003", "كهرباء ومياه", AccountType.Expense, expenses.Id)

    };

                foreach (var acc in accountsToAdd)
                {
                    acc.SetAsChild(); // تفعيل AllowPosting = true
                    context.Accounts.Add(acc);
                }

                await context.SaveChangesAsync();


            }
            var currentAssetss = await context.Accounts.FirstOrDefaultAsync(a => a.Code == "11");
            var revenues = await context.Accounts.FirstOrDefaultAsync(a => a.Code == "4");
            if (!await context.AccountMappings.AnyAsync())
            {
                // سنحتاج لجلب الـ IDs الخاصة بالحسابات التي أنشأتها للتو
                var accSuppliers = await context.Accounts.FirstAsync(a => a.Code == "2101001"); // الموردون
                var accInventoryMain = await context.Accounts.FirstAsync(a => a.Code == "1103001"); // سنستخدم العملاء مؤقتاً أو ننشئ حساب مخزن

                // ملاحظة: يفضل إضافة حساب للمخزن في شجرة الحسابات تحت الأصول المتداولة
                var inventoryAccount = new Account("1104001", "مخزن البضائع العام", AccountType.Asset, currentAssetss!.Id);
                var discountReceivedAcc = new Account("4101001", "الخصم المكتسب", AccountType.Revenue, revenues!.Id);
                var vatInputAcc = new Account("1105001", "ضريبة القيمة المضافة (مدخلات)", AccountType.Asset, currentAssetss.Id);



                var mappings = new List<AccountMapping>

    {
        // 1. ربط الموردين (بشكل عام): أي مورد ليس له حساب خاص يذهب لهذا الحساب
        new AccountMapping(MapPurpose.AccountPayable, AccountSourceType.Vendor, Guid.Empty, accSuppliers.Id),

        // 2. ربط المخزن الافتراضي: أي صنف لا يملك توجيه خاص يذهب للمخزن العام
        new AccountMapping(MapPurpose.Inventory, AccountSourceType.Category, Guid.Empty, inventoryAccount.Id),

        // 3. ربط الخصم المكتسب (Default)
        new AccountMapping(MapPurpose.DiscountReceived, AccountSourceType.Category, Guid.Empty, discountReceivedAcc.Id),

        // 4. ربط الضريبة (Default)
        new AccountMapping(MapPurpose.Tax, AccountSourceType.TaxCode, Guid.Empty, vatInputAcc.Id)
    };



                context.AccountMappings.AddRange(mappings);
                await context.SaveChangesAsync();
            }
            // جلب الحسابات التي أنشأناها للتو
            var capitalAcc = await context.Accounts.FirstOrDefaultAsync(a => a.Code == "3101001");
            var suspenseAcc = await context.Accounts.FirstOrDefaultAsync(a => a.Code == "3101003");
            var CurrencyId = await context.Currencies.Where(b => b.IsBaseCurrency).FirstOrDefaultAsync();
            if (!await context.SystemSettings.AnyAsync())
            {

                // 1. جلب حسابات الربط من قاعدة البيانات (حسب الأكواد التي أنشأتها)

                // ملاحظة: بما أنك لم تنشئ حساب فوارق تقريب في قائمتك، 
                // يمكننا استخدام حساب التسوية مؤقتاً أو إنشاء إعداد فارغ

                var settings = new List<SystemSetting>
    {
        // --- قسم المحاسبة (Accounting) ---
        new SystemSetting(
            category: "Accounting",
            key: "OB_SuspenseAccount",
            displayName: "حساب تسوية الأرصدة الافتتاحية",
            description: "الحساب الوسيط الذي يستخدمه النظام لموازنة فروقات أرصدة أول المدة آلياً.",
            value: suspenseAcc?.Id.ToString() ?? "",
            type: "Guid",
            lookupType: "Accounts",
            order: 1,
            isSystem: true),

        new SystemSetting(
            category: "Accounting",
            key: "DefaultCapitalAccount",
            displayName: "حساب رأس المال الافتراضي",
            description: "الحساب الأساسي لحقوق الملكية المستخدم في القيود الافتتاحية.",
            value: capitalAcc?.Id.ToString() ?? "",
            type: "Guid",
            lookupType: "Accounts",
            order: 2,
            isSystem: false),

        new SystemSetting(
            category: "Accounting",
            key: "AllowUnbalancedDraft",
            displayName: "حفظ المسودات غير المتزنة",
            description: "تحديد ما إذا كان يُسمح بحفظ قيود يومية غير متزنة كحالة 'مسودة'.",
            value: "false",
            type: "Boolean",
            lookupType: null,
            order: 3,
            isSystem: false),

        // --- قسم العملات (Currencies) ---
        new SystemSetting(
            category: "Currencies",
            key: "BaseCurrency",
            displayName: "العملة المحلية",
            description: "العملة الأساسية لإدارة الحسابات (مثلاً: YER أو USD).",
            value: CurrencyId!.Id.ToString() ?? "",
            type: "GuidS",
            lookupType: "Currencies",
            order: 1,
            isSystem: true),

        // --- إعدادات عامة (General) ---
        new SystemSetting(
            category: "General",
            key: "CompanyName",
            displayName: "اسم الشركة/المؤسسة",
            description: "الاسم الرسمي الذي يظهر في ترويسة التقارير والفواتير.",
            value: "شركة داتا فانس للأنظمة",
            type: "String",
            lookupType: null,
            order: 1,
            isSystem: false),

        new SystemSetting(
            category: "General",
            key: "DecimalPlaces",
            displayName: "الخانات العشرية",
            description: "عدد الأرقام بعد الفاصلة في المبالغ المالية.",
            value: "2",
            type: "Int",
            lookupType: null,
            order: 2,
            isSystem: false),
        new SystemSetting(
            category: "General",
            key: "CompanyLogo",
            displayName: "شعار الشركة",
            description: "الصورة الرسمية التي ستظهر في الهيدر والتقارير.",
            value: "", // سنخزن هنا مسار الصورة أو Base64
            type: "Image", // نوع جديد للتعامل معه في الواجهة
            lookupType: null,
            order: 3,
            isSystem: false),

        new SystemSetting(
            category: "General",
            key: "CompanyDescription",
            displayName: "وصف الشركة",
            description: "نبذة مختصرة عن نشاط الشركة تظهر في صفحة 'عن النظام'.",
            value: "شركة متخصصة في الحلول البرمجية والمحاسبية.",
            type: "TextArea", // نوع جديد للنصوص الطويلة
            lookupType: null,
            order: 4,
            isSystem: false)
            };

                context.SystemSettings.AddRange(settings);
                await context.SaveChangesAsync();
            }
            if (!await context.FinancialAccounts.AnyAsync())
            {
                var financials = new List<FinancialAccount>
                {
                    new FinancialAccount(
                        "صندوق الرئيسي",
                        "Cash main",
                        FinancialAccountType.Cash
                        ),
                     new FinancialAccount(
                        "بنك عدن",
                        "bank main",
                        FinancialAccountType.Bank
                        )
                };
                context.FinancialAccounts.AddRange(financials);
                await context.SaveChangesAsync();
            }

        }

    }
}

