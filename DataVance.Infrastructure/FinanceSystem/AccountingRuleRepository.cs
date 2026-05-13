using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class AccountingRuleRepository : IAccountingRuleRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IAccountingOperationRepository _accountingOperation;

        public AccountingRuleRepository(IApplicationDbContext context, IAccountingOperationRepository accountingOperation)
        {
            _context = context;
            _accountingOperation = accountingOperation;
        }

        public async Task<AccountingRule?> GetEffectiveRuleAsync(Guid operationId, DateTime eventDate, CancellationToken ct = default)
        {
            return await _context.AccountingRules
                .Include(r => r.Lines) // ضروري جداً لجلب تفاصيل القيود
                .Where(r => r.OperationId == operationId)
                .Where(r => r.IsActive)
                // منطق تاريخ الفعالية: التاريخ بين البداية والنهاية (أو نهاية مفتوحة)
                .Where(r => r.ValidFrom <= eventDate && (r.ValidTo == null || r.ValidTo >= eventDate))
                .OrderByDescending(r => r.Version) // جلب أحدث نسخة في حال تداخلت التواريخ
                .FirstOrDefaultAsync(ct);
        }

        public async Task AddAsync(AccountingRule rule, CancellationToken ct = default)
        {
            await _context.AccountingRules.AddAsync(rule, ct);
        }

        public async Task<IEnumerable<AccountingRule>> GetRulesByOperationIdAsync(Guid operationId, CancellationToken ct = default)
        {
            return await _context.AccountingRules
                .Include(r => r.Lines)
                .Where(r => r.OperationId == operationId)
                .OrderByDescending(r => r.ValidFrom)
                .ToListAsync(ct);
        }
        public async Task<Guid> GetAccountIdAsync(
         AccountSourceType sourceType,
         MapPurpose purpose,
         Guid? referenceId = null,
         Guid? WarehouseId = null,
        CancellationToken ct = default)
        {
            // 1. البحث الأكثر دقة (المرجع + المستودع) 🎯
            var specificWithWarehouse = await _context.AccountMappings
                .FirstOrDefaultAsync(x => x.AccountSourceType == sourceType &&
                                          x.Purpose == purpose &&
                                          x.ReferenceId == referenceId &&
                                          x.WarehouseId == WarehouseId, ct); // إضافة شرط المستودع

            if (specificWithWarehouse != null) return specificWithWarehouse.AccountId;

            // 2. البحث (المرجع فقط - لكل المستودعات)
            var specificOnly = await _context.AccountMappings
                .FirstOrDefaultAsync(x => x.AccountSourceType == sourceType &&
                                          x.Purpose == purpose &&
                                          x.ReferenceId == referenceId &&
                                          x.WarehouseId == null, ct);

            if (specificOnly != null) return specificOnly.AccountId;

            // 3. البحث عن الربط الافتراضي العام (Fallback)
            var defaultMapping = await _context.AccountMappings
                .FirstOrDefaultAsync(x => x.AccountSourceType == sourceType &&
                                          x.Purpose == purpose &&
                                          x.ReferenceId == null, ct);




            return defaultMapping?.AccountId
                   ?? throw new Exception($"تنبيه: لا يوجد توجيه محاسبي لـ ({sourceType}) بغرض ({purpose})");
        }
        //public async Task<Guid> GetAccountIdAsync(
        //       AccountSourceType sourceType,
        //       MapPurpose purpose,
        //       Guid? referenceId = null,
        //       Guid? WarehouseId =null ,
        //      CancellationToken ct = default)
        //{
        //    // 1. البحث عن الربط المخصص (مثلاً: حساب مخزون لصنف محدد)
        //    if (referenceId.HasValue)
        //    {
        //        var specificMapping = await _context.AccountMappings
        //            .FirstOrDefaultAsync(x => x.AccountSourceType == sourceType &&
        //                                      x.Purpose == purpose &&
        //                                      x.ReferenceId == referenceId, ct);

        //        if (specificMapping != null) return specificMapping.AccountId;
        //    }

        //    // 2. البحث عن الربط الافتراضي لهذا المصدر والغرض (Default)
        //    // ملاحظة: الـ ReferenceId هنا سيكون فارغاً (مثلاً: حساب مبيعات عام للفئة)
        //    var defaultMapping = await _context.AccountMappings
        //        .FirstOrDefaultAsync(x => x.AccountSourceType == sourceType &&
        //                                  x.Purpose == purpose &&
        //                                  x.ReferenceId == Guid.Empty, ct); // أو null حسب تصميمك

        //    return defaultMapping?.AccountId
        //           ?? throw new Exception($"تنبيه: لا يوجد توجيه محاسبي لـ ({sourceType}) بغرض ({purpose})");
        //}
        public async Task<AccountingRule> GetActiveRuleAsync(string operationCode, DateTime eventDate, CancellationToken ct)
        {
            // 1. البحث عن القاعدة المرتبطة بالكود المحدد (مثل PUR_RCT)
            // 2. يجب أن يكون تاريخ الحدث يقع ضمن نطاق صلاحية القاعدة
            // 3. يجب أن تكون القاعدة نشطة (IsActive)
            // 4. في حال وجود أكثر من إصدار، نأخذ الإصدار الأحدث (Highest Version)
            var operation = await _accountingOperation.GetByCodeAsync(operationCode, ct);
            if (operation == null)
            {
                throw new InvalidOperationException($"  الرحاء ضبط العملية المحاسبية  {operation} في تاريخ {eventDate:yyyy-MM-dd}");

            }
            var rule = await _context.AccountingRules
                .Include(r => r.Lines) // تحميل الأسطر (Template Lines)
                .Where(r => r.OperationId == operation.Id &&
                            r.IsActive &&
                            eventDate >= r.ValidFrom &&
                            (r.ValidTo == null || eventDate <= r.ValidTo))
                .OrderByDescending(r => r.Version)
                .FirstOrDefaultAsync(ct);

            if (rule == null)
            {
                // يمكنك هنا رمي Exception مخصص أو تسجيل Log لغياب القاعدة
                throw new InvalidOperationException($"لا توجد قاعدة محاسبية نشطة للعملية {operationCode} في تاريخ {eventDate:yyyy-MM-dd}");
            }

            return rule;
        }
    }
}
