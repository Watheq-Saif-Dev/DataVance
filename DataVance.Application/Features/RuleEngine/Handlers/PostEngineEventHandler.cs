using DataVance.Application.Common.Events;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Application.Features.RuleEngine.JournalBuilders;
using DataVance.Domain.Finance.Rules.Events;
using MediatR;
namespace DataVance.Application.Features.RuleEngine.Handlers
{
    public class PostEngineEventHandler
         : INotificationHandler<DomainEventNotification<PostToAccountingEvent>>
    {
        private readonly PostingContextFactory _contextFactory;
        private readonly PostingJournal _postingEngine;
        public PostEngineEventHandler(PostingContextFactory contextFactory, PostingJournal postingEngine)
        {
            _contextFactory = contextFactory;
            _postingEngine = postingEngine;
        }
        public async Task Handle(DomainEventNotification<PostToAccountingEvent> notification, CancellationToken ct)
        {
            var @event = notification.DomainEvent;
            var contextResult = await _contextFactory.CreateAsync(@event.OperationCode, @event.ReferenceId, @event.BranchId, ct);
            if (!contextResult.Succeeded || contextResult.Value == null)
            {
                // TODO: Log failure and handle dead-letter queue or retry
                throw new InvalidOperationException($"Posting failed to build context: {string.Join(", ", contextResult.Errors)}");
            }

            var journalResult = await _postingEngine.PostAsync(contextResult.Value, ct);
            if (!journalResult.Succeeded)
            {
                // TODO: Log failure
                throw new InvalidOperationException($"Posting failed during journal creation: {string.Join(", ", journalResult.Errors)}");
            }
        }
    }
}




