using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Journal.Event
{
    public class JournalPostedEvent : IDomainEvent
    {
        public Guid JournalEntryId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public JournalPostedEvent(Guid id)
        {
            JournalEntryId = id;
        }
    }
}
