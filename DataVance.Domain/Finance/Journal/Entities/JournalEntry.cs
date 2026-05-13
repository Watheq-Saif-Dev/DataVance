using DataVance.Domain.Common;
using DataVance.Domain.Finance.Journal.Event;
using DataVance.Domain.Finance.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Journal.Entities
{
    public class JournalEntry : BaseBranchEntity
    {
        private readonly List<JournalEntryLine> _lines = new();

        public string EntryNumber { get; private set; }
        public DateTime EntryDate { get; private set; }
        //public Guid? BranchId { get; private set; }
        public Guid FiscalYearId { get; private set; }
        public Guid FiscalPeriodId { get; private set; }
        public Guid CurrencyId { get; private set; } // الربط مع جدول العملات
        public string? CurrencyCode { get; private set; } // للوصول السريع (مثل USD)
        public decimal ExchangeRate { get; private set; }
        public JournalStatus Status { get; private set; }
        public string Description { get; private set; }
        public Guid? ReversedEntryId { get; private set; }
        public JournalEntryType Type { get; private set; }
        //public string? CreatedBy { get; set; }

        public IReadOnlyCollection<JournalEntryLine> Lines => _lines;

        private JournalEntry() { }

        public JournalEntry(
            string entryNumber,
            DateTime date,
            Guid branchId,
            Guid fiscalYearId,
            Guid fiscalPeriodId,
            Guid currencyId,
            string? currencyCode,
            decimal exchangeRate)
        {
            EntryNumber = entryNumber;
            EntryDate = date;
            BranchId = branchId;
            FiscalYearId = fiscalYearId;
            FiscalPeriodId = fiscalPeriodId;
            CurrencyId = currencyId;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            Status = JournalStatus.Draft;
            Type = JournalEntryType.Standard;
        }



        public JournalEntry CreateReversal(string newEntryNumber, string reason)
        {
            if (Status != JournalStatus.Posted)
                throw new InvalidOperationException("لا يمكن عكس قيد إلا إذا كانت حالته 'مرحل' (Posted).");

            var reversalEntry = new JournalEntry(
                newEntryNumber,
                DateTime.UtcNow,
                BranchId,
                FiscalYearId,
                FiscalPeriodId,
                CurrencyId,
                CurrencyCode,
                ExchangeRate);

            foreach (var line in _lines)
            {
                reversalEntry.AddLine(
                    line.AccountId,
                    line.TransactionCredit.Amount,
                    line.TransactionDebit.Amount,
                    line.CostCenterId,
                    line.TransactionCredit.CurrencyId,
                    line.ExchangeRate);
            }

            reversalEntry.Description = $"إلغاء وعكس القيد رقم {EntryNumber}. السبب: {reason}";
            reversalEntry.ReversedEntryId = Id;
            Status = JournalStatus.Reversed;
            reversalEntry.Post(isSystemGenerated: true);

            return reversalEntry;
        }

        public void AddLine(Guid accountId, decimal debit, decimal credit, Guid? costCenterId, Guid currencyId, decimal exchangeRate)
        {
            if (debit > 0 && credit > 0)
                throw new InvalidOperationException("Line cannot be both debit and credit.");

            var transactionDebit = new DataVance.Domain.Common.Models.Money(debit, currencyId);
            var transactionCredit = new DataVance.Domain.Common.Models.Money(credit, currencyId);
            
            // حساب القيمة بالعملة المحلية (Base Currency) - افترضنا أن CurrencyId للقيد هي العملة المحلية
            var baseDebit = new DataVance.Domain.Common.Models.Money(debit * exchangeRate, CurrencyId);
            var baseCredit = new DataVance.Domain.Common.Models.Money(credit * exchangeRate, CurrencyId);

            _lines.Add(new JournalEntryLine(
                accountId,
                transactionDebit,
                transactionCredit,
                baseDebit,
                baseCredit,
                costCenterId,
                exchangeRate));
        }

        private void SetStatus(JournalStatus newStatus) => Status = newStatus;

        public void UpdateHeader(DateTime entryDate, string description, Guid currencyId, decimal exchangeRate)
        {
            if (exchangeRate <= 0) exchangeRate = 1;
            EntryDate = entryDate;
            Description = description;
            CurrencyId = currencyId;
            ExchangeRate = exchangeRate;
        }

        public void ClearLines() => _lines.Clear();

        public void UpdateDescription(string description)
        {
            if (Status == JournalStatus.Posted)
                throw new InvalidOperationException("لا يمكن تعديل بيان قيد مرحل.");
            Description = description;
        }

        public bool CanDelete() => Status == JournalStatus.Draft;
        public bool CanEdit() => Status == JournalStatus.Draft;

        public void Approve()
        {
            if (Status != JournalStatus.Draft)
                throw new InvalidOperationException("يمكن اعتماد القيود الموجودة في حالة مسودة فقط.");

            ValidateBalance();
            Status = JournalStatus.Approved;
        }

        public void ValidateBalance()
        {
            if (_lines.Count < 2)
                throw new InvalidOperationException("Entry must contain at least two lines.");

            decimal totalDebit  = _lines.Sum(x => x.BaseDebit.Amount);
            decimal totalCredit = _lines.Sum(x => x.BaseCredit.Amount);

            if (Math.Abs(totalDebit - totalCredit) > 0.0001m)
                throw new InvalidOperationException("القيد غير متزن بالعملة المحلية.");
        }

        // State Machine: Approved → Draft (لا يُسمح من Posted أو Reversed)
        public void Unapprove()
        {
            if (Status != JournalStatus.Approved)
                throw new InvalidOperationException("لا يمكن فك الاعتماد إلا للقيود المعتمدة فقط.");

            Status = JournalStatus.Draft;
        }




        public void Post(bool isSystemGenerated = false)
        {
            // إذا كان القيد ناتج عن النظام (مثل العكس)، نتجاوز شرط الاعتماد اليدوي
            if (!isSystemGenerated && Status != JournalStatus.Approved)
                throw new InvalidOperationException("لا يمكن ترحيل القيد إلا إذا كان في حالة 'معتمد'.");

            ValidateBalance();

            Status = JournalStatus.Posted;
            AddDomainEvent(new JournalPostedEvent(Id)); // إطلاق المنطق الذهبي للأرصدة [cite: 2026-03-01]
        }
    }
}
