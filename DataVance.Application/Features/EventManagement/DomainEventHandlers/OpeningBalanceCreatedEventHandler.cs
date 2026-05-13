using DataVance.Application.Common.Events;
using DataVance.Domain.Finance.OpeningBalances.Event;
using DataVance.Domain.Finance.Rules.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DataVance.Application.Features.EventManagement.DomainEventHandlers
{
    public class OpeningBalanceCreatedEventHandler
        : INotificationHandler<DomainEventNotification<OpeningBalanceCreatedEvent>>
    {
        private readonly IMediator _mediator;

        public OpeningBalanceCreatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<OpeningBalanceCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var openingBalance = notification.DomainEvent.OpeningBalance;
            
            await _mediator.Publish(new DomainEventNotification<PostToAccountingEvent>(
                new PostToAccountingEvent(openingBalance.Id, "ACC_OB", openingBalance.OpeningDate, openingBalance.BranchId)), cancellationToken);
        }
    }
}
