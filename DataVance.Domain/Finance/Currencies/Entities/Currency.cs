using DataVance.Domain.Common;
using DataVance.Domain.Finance.Currencies.Entities;
using DataVance.Domain.Finance.Currencies.Event;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Currencies.Entities
{
    public class Currency : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public int DecimalPlaces { get; private set; }
        public bool IsBaseCurrency { get; private set; }
        public bool IsActive { get; private set; }


        public decimal CurrentExchangeRate { get; private set; }
        public DateTime LastRateUpdate { get; private set; }
        private Currency() { }

        private Currency(string code, string name, string symbol, int decimalPlaces, bool isBase, decimal rate)
        {
            Id = Guid.NewGuid(); // نولد الـ ID هنا لضمان وجوده للحدث
            Code = code;
            Name = name;
            Symbol = symbol;
            DecimalPlaces = decimalPlaces;
            IsBaseCurrency = isBase;
            IsActive = true;
            CurrentExchangeRate = isBase ? 1 : rate;
        }

        public static Currency Create(string code, string name, string symbol, int decimalPlaces, bool isBase, decimal rate)
        {
            var currency = new Currency(code, name, symbol, decimalPlaces, isBase, rate);

            // هنا نضع الحدث بكل أمان!
            currency.AddDomainEvent(new ExchangeRateChangedEvent(
                currency.Id,
                currency.CurrentExchangeRate,
                DateTime.UtcNow
            ));

            return currency;
        }
        public void UpdateDetails(string name, string symbol, int decimalPlaces, bool isActive)
        {
            // 1. التحقق من البيانات (Validation)
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("اسم العملة لا يمكن أن يكون فارغاً.");

            if (string.IsNullOrWhiteSpace(symbol))
                throw new InvalidOperationException("رمز العملة (Symbol) لا يمكن أن يكون فارغاً.");

            if (decimalPlaces < 0 || decimalPlaces > 4)
                throw new InvalidOperationException("عدد الخانات العشرية يجب أن يكون بين 0 و 4.");

            // 2. منع إيقاف العملة الأساسية (قاعدة عمل احترافية)
            if (IsBaseCurrency && !isActive)
                throw new InvalidOperationException("لا يمكن إيقاف العملة الأساسية للنظام.");

            // 3. تحديث القيم
            Name = name;
            Symbol = symbol;
            DecimalPlaces = decimalPlaces;
            IsActive = isActive;

            // ملاحظة: لا نحدث السعر هنا لأن له دالة خاصة (UpdateRate) تطلق حدثاً (Event)
        }
        public void UpdateRate(decimal newRate, DateTime effectiveDate)
        {
            if (IsBaseCurrency && newRate != 1)
                throw new Exception("العملة الأساسية يجب أن يكون سعرها دائماً 1.");

            if (newRate <= 0)
                throw new Exception("سعر الصرف يجب أن يكون أكبر من صفر.");

            // تحديث الحالة الداخلية
            CurrentExchangeRate = newRate;
            LastRateUpdate = effectiveDate;

            // هنا نطلق "Domain Event" ليقوم الـ Handler بحفظ السجل في جدول الـ History
            AddDomainEvent(new ExchangeRateChangedEvent(Id, newRate, effectiveDate));

            if (IsBaseCurrency) throw new InvalidOperationException("لا يمكن تغيير سعر صرف العملة المحلية.");
            CurrentExchangeRate = newRate;

        }
        public ExchangeRate UpdateExchangeRate(decimal newRate, DateTime effectiveDate)
        {
            if (IsBaseCurrency && newRate != 1)
                throw new Exception("العملة الأساسية يجب أن يكون سعرها دائماً 1.");

            if (newRate <= 0)
                throw new Exception("سعر الصرف يجب أن يكون أكبر من صفر.");

            // تحديث الحالة الداخلية
            CurrentExchangeRate = newRate;
            LastRateUpdate = effectiveDate;

            return new ExchangeRate(Id, newRate, effectiveDate);
            // هنا نطلق "Domain Event" ليقوم الـ Handler بحفظ السجل في جدول الـ History
            //AddDomainEvent(new ExchangeRateChangedEvent(this.Id, newRate, effectiveDate));
        }
        public void SetAsBaseCurrency()
        {
            IsBaseCurrency = true;
            CurrentExchangeRate = 1; // العملة الأساسية دائماً قيمتها 1 مقابل نفسها

            // إطلاق حدث لإعادة حساب أسعار العملات الأخرى بناءً على الأساس الجديد (اختياري)
            //AddDomainEvent(new BaseCurrencyChangedEvent(this.Id));
        }

        public void UnsetBaseCurrency()
        {
            IsBaseCurrency = false;
            // عند إلغاء كونها أساسية، يجب تحديث سعر صرفها فوراً ليكون لها قيمة مقابل الأساس الجديد
        }


        // دالة لتغيير الحالة
        public void ToggleStatus() => IsActive = !IsActive;
    }
}
