using DataVance.Domain.Common;
using DataVance.Domain.Finance.OpeningBalances.Entities;

namespace DataVance.Domain.Finance.OpeningBalances.Event
{
    // يرث من واجهة IDomainEvent التي أرسلتها أنت سابقاً
    public class OpeningBalanceCreatedEvent : IDomainEvent
    {
        public OpeningBalance OpeningBalance { get; }

        public OpeningBalanceCreatedEvent(OpeningBalance openingBalance)
        {
            OpeningBalance = openingBalance;
        }
    }
}

