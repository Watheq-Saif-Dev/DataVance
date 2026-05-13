using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.AccountingClosing.Entities
{
    public class FiscalPeriod : AggregateRoot
    {
        public Guid FiscalYearId { get; private set; }
        public int MonthNumber { get; private set; }
        public string Name { get; private set; } = "";
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsClosed { get; private set; }
        public bool IsClosingPeriod { get; private set; }
        private FiscalPeriod() { }

        public FiscalPeriod(Guid fiscalYearId, int monthNumber, string name, DateTime start, DateTime end, bool isClosing = false)
        {
            FiscalYearId = fiscalYearId;
            MonthNumber = monthNumber;
            Name = name;
            StartDate = start;
            EndDate = end;
            IsClosed = false;
            IsClosingPeriod = isClosing;
        }

        public Guid? ClosingJournalId { get; private set; }

        public void ClosePeriod(Guid? journalId = null)
        {
            if (IsClosed)
                throw new InvalidOperationException($"Fiscal Period {Name} is already closed.");
            
            ClosingJournalId = journalId;
            IsClosed = true;
        }

        public void OpenPeriod()
        {
            IsClosed = false;
            ClosingJournalId = null;
        }

    }
}
