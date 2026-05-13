using DataVance.Domain.Common;
using DataVance.Domain.Common.Models;

namespace DataVance.Domain.Finance.Accounting.Entities
{
    public class AccountBalance : Entity
    {
        public Guid AccountId { get; private set; }
        public Guid BranchId { get; private set; }
        public Guid FiscalPeriodId { get; private set; }
        // الأرصدة بالعملة الأجنبية
        public Money Debit { get; private set; }
        public Money Credit { get; private set; }
        public Money Balance => Debit - Credit;

        // الأرصدة بالعملة المحلية
        public Money LocalDebit { get; private set; }
        public Money LocalCredit { get; private set; }
        public Money LocalBalance => LocalDebit - LocalCredit;
        private AccountBalance() { }

        public AccountBalance(Guid accountId, Guid branchId, Guid periodId, Guid currencyId, Guid baseCurrencyId)
        {
            AccountId = accountId;
            BranchId = branchId;
            FiscalPeriodId = periodId;
            Debit = Credit = Money.Zero(currencyId);
            LocalDebit = LocalCredit = Money.Zero(baseCurrencyId);
        }


        public void UpdateBalance(Money amount, Money localAmount, bool isDebit)
        {
            if (isDebit)
            {
                Debit += amount;
                LocalDebit += localAmount;
            }
            else
            {
                Credit += amount;
                LocalCredit += localAmount;
            }
        }
    }
}

