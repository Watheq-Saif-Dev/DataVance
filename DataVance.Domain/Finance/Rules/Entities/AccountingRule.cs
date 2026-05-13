using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Rules.Entities
{
    public class AccountingRule : BaseBranchEntity
    {
        public Guid OperationId { get; private set; }
        public string JournalEntryType { get; private set; } // نوع القيد (مثال: "SYS-OB")
        public bool AutoPost { get; private set; }           // هل يُرحل تلقائياً؟


        public string? Description { get; set; }

        // 🔥 Versioning & Effective Date Logic (المستوى العالمي)
        public int Version { get; private set; }
        public DateTime ValidFrom { get; private set; }
        public DateTime? ValidTo { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<AccountingRuleLine> _lines = new();
        public IReadOnlyCollection<AccountingRuleLine> Lines => _lines.AsReadOnly();

        private AccountingRule() { } // For EF Core

        public AccountingRule(Guid operationId, string journalEntryType, bool autoPost, DateTime validFrom, DateTime? validTo = null, int version = 1)
        {
            OperationId = operationId;
            JournalEntryType = journalEntryType;
            AutoPost = autoPost;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Version = version;
            IsActive = true;
        }

        public void AddLine(AccountingRuleLine line)
        {
            _lines.Add(line);
        }

        // دالة مساعدة لمعرفة ما إذا كانت القاعدة سارية في تاريخ معين
        public bool IsEffective(DateTime date)
        {
            return IsActive && date >= ValidFrom && (!ValidTo.HasValue || date <= ValidTo.Value);
        }
    }
}
