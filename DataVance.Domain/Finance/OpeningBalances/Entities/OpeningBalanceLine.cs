using DataVance.Domain.Common;
using DataVance.Domain.Common.Models;

namespace DataVance.Domain.Finance.OpeningBalances.Entities
{
    public class OpeningBalanceLine : Entity
    {
        public Guid AccountId { get; private set; }
        public Money Debit { get; private set; }
        public Money Credit { get; private set; }

        public Guid OpeningBalanceId { get; private set; } // Foreign Key

        private OpeningBalanceLine() { }

        public OpeningBalanceLine(Guid accountId, Money debit, Money credit)
        {
            AccountId = accountId;
            Debit = debit;
            Credit = credit;
        }
    }
}

