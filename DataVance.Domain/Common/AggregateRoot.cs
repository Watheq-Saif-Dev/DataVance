using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Common
{
    public abstract class AggregateRoot : BaseEntity, IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);

        // Clear all domain events after they have been dispatched
        public void ClearDomainEvents()
            => _domainEvents.Clear();
    }
}
