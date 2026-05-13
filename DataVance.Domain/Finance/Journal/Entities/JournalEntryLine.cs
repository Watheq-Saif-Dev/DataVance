using DataVance.Domain.Common;
using DataVance.Domain.Common.Models;

namespace DataVance.Domain.Finance.Journal.Entities
{
    public class JournalEntryLine : Entity
    {
        public Guid AccountId { get; private set; }
        public Money TransactionDebit { get; private set; }
        public Money TransactionCredit { get; private set; }
        public Money BaseDebit { get; private set; }
        public Money BaseCredit { get; private set; }
        public Guid? CostCenterId { get; private set; }
        public decimal ExchangeRate { get; private set; } 

        private JournalEntryLine() { }

        public JournalEntryLine(
            Guid accountId,
            Money transactionDebit,
            Money transactionCredit,
            Money baseDebit,
            Money baseCredit,
            Guid? costCenterId,
            decimal exchangeRate)
        {
            AccountId = accountId;
            TransactionDebit = transactionDebit;
            TransactionCredit = transactionCredit;
            BaseDebit = baseDebit;
            BaseCredit = baseCredit;
            CostCenterId = costCenterId;
            ExchangeRate = exchangeRate;
        }
    }
}
