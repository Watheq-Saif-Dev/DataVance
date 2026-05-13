using DataVance.Domain.Common;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Rules.Entities
{
    public class AccountingRuleLine : BaseEntity
    {
        public Guid RuleId { get; private set; }
        public EntrySide EntrySide { get; private set; }
        public AccountSourceType AccountSourceType { get; private set; }
        public Guid? StaticAccountId { get; private set; } // يُستخدم فقط إذا كان الـ SourceType هو StaticAccount
        public AmountSourceType AmountSourceType { get; private set; }
        public MapPurpose Purpose { get; private set; }
        public int Order { get; private set; } // ترتيب السطر في القيد

        private AccountingRuleLine() { } // For EF Core

        public AccountingRuleLine(EntrySide side, AccountSourceType accountSource, AmountSourceType amountSource, int order, Guid? staticAccountId = null, MapPurpose? purpose = null)
        {
            EntrySide = side;
            AccountSourceType = accountSource;
            AmountSourceType = amountSource;
            Order = order;
            StaticAccountId = staticAccountId;
        }

    }
}
