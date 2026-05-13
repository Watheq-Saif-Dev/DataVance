using DataVance.Application.Common;
using DataVance.Application.Common.Events;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Currencies.Entities;
using DataVance.Domain.Finance.Currencies.Event;
using MediatR;

namespace DataVance.Application.Features.EventManagement.EventHandler.Event
{
    public class ExchangeRateChangedAuditHandler : INotificationHandler<DomainEventNotification<ExchangeRateChangedEvent>>
    {
        private readonly IExchangeRateRepository _historyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExchangeRateChangedAuditHandler(IExchangeRateRepository historyRepository, IUnitOfWork unitOfWork)
        {
            _historyRepository = historyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DomainEventNotification<ExchangeRateChangedEvent> notification, CancellationToken ct)
        {
            var @event = notification.DomainEvent;

            var historyRecord = new ExchangeRate(
                @event.CurrencyId,
                @event.NewRate,
                @event.EffectiveDate
            );

            await _historyRepository.AddAsync(historyRecord, ct);
        }

        //



    }
}


