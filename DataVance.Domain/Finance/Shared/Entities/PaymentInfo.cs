using DataVance.Domain.Finance.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Shared.Entities
{
    public class PaymentInfo
    {
        public PaymentMethodType Method { get; private set; }

        public Guid? FinancialAccountId { get; private set; }

        // بيانات إضافية للتوثيق (رقم التحويل، رقم الشيك، إلخ)
        public string? ReferenceNo { get; private set; }

        private PaymentInfo() { }

        public PaymentInfo(PaymentMethodType method, Guid? financialAccountId = null, string? referenceNo = null)
        {
            if (method != PaymentMethodType.Credit && financialAccountId == null)
                throw new InvalidOperationException("يجب تحديد الحساب المالي للعمليات غير الآجلة");

            Method = method;
            FinancialAccountId = financialAccountId;
            ReferenceNo = referenceNo;
        }
    }
}

