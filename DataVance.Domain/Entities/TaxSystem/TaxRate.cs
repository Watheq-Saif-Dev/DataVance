using DataVance.Domain.Common;

namespace DataVance.Domain.Entities.TaxSystem
{

    public class TaxRate : BaseEntity
    {
        // النسبة المئوية (مثلاً 15.00)
        public decimal Percentage { get; private set; }

        // تاريخ بدء سريان النسبة
        public DateTime ValidFrom { get; private set; }

        // تاريخ الانتهاء (Null يعني سارية المفعول حتى إشعار آخر)
        public DateTime? ValidTo { get; private set; }

        // الربط مع كود الضريبة
        public Guid TaxCodeId { get; private set; }

        // EF Core Constructor
        protected TaxRate() { }

        // الباني الرئيسي (يُستدعى من داخل TaxCode)
        public TaxRate(decimal percentage, DateTime validFrom, DateTime? validTo = null)
        {
            if (percentage < 0)
                throw new ArgumentException("النسبة المئوية لا يمكن أن تكون سالبة.");

            if (validTo.HasValue && validTo < validFrom)
                throw new ArgumentException("تاريخ الانتهاء لا يمكن أن يكون قبل تاريخ البدء.");

            Percentage = percentage;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        // فعل (Behavior) لإيقاف النسبة الحالية عند إضافة نسبة جديدة
        public void Expire(DateTime expiryDate)
        {
            if (expiryDate < ValidFrom)
                throw new InvalidOperationException("لا يمكن إنهاء النسبة قبل تاريخ بدئها.");

            ValidTo = expiryDate;
        }

        // دالة مساعدة للتحقق مما إذا كانت النسبة فعالة في تاريخ معين
        public bool IsActiveAt(DateTime date)
        {
            return date >= ValidFrom && (!ValidTo.HasValue || date <= ValidTo.Value);
        }
    }
}
