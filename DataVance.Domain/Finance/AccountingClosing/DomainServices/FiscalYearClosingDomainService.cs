using DataVance.Domain.Finance.AccountingClosing.Entities;
using DataVance.Domain.Finance.Journal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVance.Domain.Finance.AccountingClosing.DomainServices
{
    public class FiscalYearClosingDomainService
    {
        public JournalEntry GenerateClosingEntry(
            FiscalYear fiscalYear, 
            IEnumerable<dynamic> balancesToClose, // استبدل بـ AccountBalance إذا توفر
            string closingEntryNumber, 
            Guid branchId, 
            Guid retainedEarningsAccountId,
            Guid baseCurrencyId)
        {
            if (fiscalYear == null) throw new ArgumentNullException(nameof(fiscalYear), "السنة المالية غير موجودة.");
            if (fiscalYear.IsClosed) throw new InvalidOperationException("السنة مغلقة مسبقاً.");

            if (!balancesToClose.Any())
                throw new InvalidOperationException("لا توجد حركات مالية لإقفالها.");

            var closingEntry = new JournalEntry(
                closingEntryNumber,
                fiscalYear.EndDate,
                branchId,
                fiscalYear.Id,
                Guid.Empty, 
                baseCurrencyId,
                "Base", 
                1m);

            decimal totalNetIncome = 0;

            foreach (var bal in balancesToClose)
            {
                if (bal.NetBalance == 0) continue;

                if (bal.NetBalance > 0) 
                {
                    closingEntry.AddLine(bal.AccountId, debit: 0, credit: Math.Abs(bal.NetBalance), costCenterId: null, currencyId: baseCurrencyId, exchangeRate: 1m);
                    totalNetIncome -= bal.NetBalance;
                }
                else 
                {
                    closingEntry.AddLine(bal.AccountId, debit: Math.Abs(bal.NetBalance), credit: 0, costCenterId: null, currencyId: baseCurrencyId, exchangeRate: 1m);
                    totalNetIncome += Math.Abs(bal.NetBalance);
                }
            }

            if (totalNetIncome > 0)
            {
                closingEntry.AddLine(retainedEarningsAccountId, debit: 0, credit: totalNetIncome, costCenterId: null, currencyId: baseCurrencyId, exchangeRate: 1m);
            }
            else if (totalNetIncome < 0)
            {
                closingEntry.AddLine(retainedEarningsAccountId, debit: Math.Abs(totalNetIncome), credit: 0, costCenterId: null, currencyId: baseCurrencyId, exchangeRate: 1m);
            }

            closingEntry.Post();
            fiscalYear.Close(closingEntry.Id);

            return closingEntry;
        }
    }
}
