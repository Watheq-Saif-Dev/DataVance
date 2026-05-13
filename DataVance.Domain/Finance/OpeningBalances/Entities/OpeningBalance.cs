using DataVance.Domain.Common;
using DataVance.Domain.Finance.OpeningBalances.Event;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.OpeningBalances.Entities
{
    public class OpeningBalance : AggregateRoot
    {
        private readonly List<OpeningBalanceLine> _lines = new();

        public DateTime OpeningDate { get; private set; }
        public Guid BranchId { get; private set; }
        public Guid CurrencyId { get; private set; }
        public string? CurrencyCode { get; private set; }
        public decimal ExchangeRate { get; private set; }
        public bool IsPosted { get; private set; }
        public Guid? JournalEntryId { get; private set; }
        public IReadOnlyCollection<OpeningBalanceLine> Lines => _lines;
        private OpeningBalance() { }

        public OpeningBalance(
                              DateTime openingDate,
                              Guid branchId,
                              Guid currencyId,
                              string? currencyCode,
                              decimal exchangeRate)
        {
            // المنطق الذهبي: الفرع إلزامي وسعر الصرف لا يقل عن 1 [cite: 2026-03-01]
            if (branchId == Guid.Empty) throw new ArgumentException("BranchId is mandatory.");

            OpeningDate = openingDate;
            BranchId = branchId;
            CurrencyId = currencyId;
            CurrencyCode = currencyCode;

            ExchangeRate = exchangeRate <= 0 ? 1m : exchangeRate;
            IsPosted = false;
            AddDomainEvent(new OpeningBalanceCreatedEvent(this));
        }
        public void BalanceWithSuspenseAccount(Guid suspenseAccountId)
        {
            var totalDebit = _lines.Sum(x => x.Debit.Amount);
            var totalCredit = _lines.Sum(x => x.Credit.Amount);
            var difference = totalDebit - totalCredit;

            if (Math.Abs(difference) > 0.0001m)
            {
                if (difference > 0) // المدين أكبر -> نحتاج سطر دائن
                    AddLine(suspenseAccountId, 0, Math.Abs(difference));
                else // الدائن أكبر -> نحتاج سطر مدين
                    AddLine(suspenseAccountId, Math.Abs(difference), 0);
            }
        }
        public void AddLine(Guid accountId, decimal debit, decimal credit)
        {
            if (debit > 0 && credit > 0)
                throw new InvalidOperationException("لا يمكن أن يكون السطر مدين ودائن معاً.");

            _lines.Add(new OpeningBalanceLine(accountId, new DataVance.Domain.Common.Models.Money(debit, CurrencyId), new DataVance.Domain.Common.Models.Money(credit, CurrencyId)));
        }
        public void MarkAsPosted(Guid journalEntryId)
        {
            if (IsPosted)
                throw new InvalidOperationException("هذا الرصيد الافتتاحي مرحل بالفعل ولا يمكن ترحيله مرة أخرى.");

            IsPosted = true;
            JournalEntryId = journalEntryId;

            // إذا كنت تستخدم Domain Events لتحديث الأرصدة لاحقاً
            //AddDomainEvent(new OpeningBalancePostedEvent(this.Id));
        }
        public void EnsureBalanced()
        {
            var totalDebit = _lines.Sum(x => x.Debit.Amount);
            var totalCredit = _lines.Sum(x => x.Credit.Amount);
            // Balancing Guard: الفرق ضمن هامش 0.0001 [cite: 2026-03-01]
            if (Math.Abs(totalDebit - totalCredit) > 0.0001m)
                throw new Exception("المستند غير متزن محاسبياً.");
        }
        public void Approve()
        {
            //AddDomainEvent(new OpeningBalanceApprovedEvent(Id));
        }
    }
}

