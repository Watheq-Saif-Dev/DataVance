using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.PaymentMethods
{
    public enum PaymentMethodType
    {
        [Description("نقداً")]
        Cash = 1,          // نقدي: يؤثر على حساب الصندوق مباشرة
        [Description("آجل")]
        Credit = 2,        // آجل: يؤثر على حساب المورد (ذمم دائنة)
        [Description("شبكة / تحويل")]
        BankTransfer = 3,  // تحويل بنكي: يؤثر على حساب البنك
        [Description("شبكة/بطاقة")]
        Network = 4,        // شبكة/بطاقة: يؤثر على حساب البنك (مع احتمالية وجود عمولة)
        [Description("الي حساب")]
        Account
    }
}

