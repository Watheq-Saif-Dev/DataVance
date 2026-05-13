using DataVance.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Events
{
    public class DomainEventNotification<T> : INotification where T : IDomainEvent
    {
        public T DomainEvent { get; }
        public DomainEventNotification(T domainEvent) => DomainEvent = domainEvent;
    }
}
