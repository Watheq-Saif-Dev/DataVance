using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.PaymentMethods
{


    public class FinancialAccount : BaseBranchEntity
    {
        public string NameAr { get; private set; } = null!;
        public string NameEn { get; private set; } = null!;
        public FinancialAccountType AccountType { get; private set; }

        //// الربط مع شجرة الحسابات (Chart of Accounts)
        //// هذا الحساب هو الذي سيتأثر بالقيود المحاسبية
        //public Guid ChartOfAccountId { get; private set; }

        public string? AccountNumber { get; private set; } // رقم الحساب البنكي (اختياري للصناديق)
        public string? IBAN { get; private set; }          // خاص بالبنوك
        public bool IsActive { get; private set; } = true;

        private FinancialAccount() { }

        public FinancialAccount(string nameAr, string nameEn, FinancialAccountType type)
        {
            Id = Guid.NewGuid();
            NameAr = nameAr;
            NameEn = nameEn;
            AccountType = type;

        }

        public void Deactivate() => IsActive = false;
    }

}

