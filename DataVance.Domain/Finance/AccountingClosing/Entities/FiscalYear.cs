using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.AccountingClosing.Entities
{
    public class FiscalYear : AggregateRoot
    {
        private readonly List<FiscalPeriod> _periods = new();

        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsClosed { get; private set; }
        public bool IsActive { get; private set; }

        private FiscalYear() { }
        public virtual IReadOnlyCollection<FiscalPeriod> Periods => _periods;

        public FiscalYear(string name, DateTime start, DateTime end)
        {
            Name = name;
            StartDate = start;
            EndDate = end;
            IsClosed = false;
            IsActive = true;

            GeneratePeriods(); // توليد الشهور تلقائياً عند إنشاء السنة
        }
        private void GeneratePeriods()
        {
            // تقسيم السنة إلى 12 شهراً تلقائياً
            for (int i = 1; i <= 12; i++)
            {
                var periodStart = StartDate.AddMonths(i - 1);
                var periodEnd = periodStart.AddMonths(1).AddDays(-1);

                _periods.Add(new FiscalPeriod(Id, i, periodStart.ToString("MMMM yyyy"), periodStart, periodEnd));
            }
            // تبدأ وتنتهي عادةً في آخر يوم من السنة
            _periods.Add(new FiscalPeriod(
                Id,
                13,
                "فترة تسويات " + StartDate.Year,
                EndDate,
                EndDate,
                isClosing: true
            ));
        }

        public Guid? ClosingJournalId { get; private set; }

        public void Close(Guid journalId)
        {
            if (IsClosed)
                throw new InvalidOperationException("Year already closed.");

            if (_periods.Any(p => !p.IsClosed && !p.IsClosingPeriod))
                 throw new InvalidOperationException("Cannot close year: All regular periods must be closed first.");

            ClosingJournalId = journalId;
            IsClosed = true;
        }

    }
}
