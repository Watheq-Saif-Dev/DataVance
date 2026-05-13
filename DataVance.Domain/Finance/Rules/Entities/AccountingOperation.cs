using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Rules.Entities
{
    public class AccountingOperation : BaseBranchEntity
    {
        public string Code { get; private set; } = null!; // مثال: "OpeningBalance" أو "SalesInvoice"
        public string Name { get; private set; } = null!; // الاسم للعرض في الشاشات
        public bool IsSystem { get; private set; }        // هل هي عملية أساسية في النظام لا يمكن حذفها؟

        private AccountingOperation() { } // For EF Core

        public AccountingOperation(string code, string name, bool isSystem = true)
        {
            Code = code;
            Name = name;
            IsSystem = isSystem;
        }
    }
}
