using DataVance.Domain.Common;

namespace DataVance.Domain.Finance.Currencies.Event
{
    // الآن بما أن IDomainEvent ترث من INotification، سيختفي الخطأ فوراً
    public record ExchangeRateChangedEvent(
        Guid CurrencyId,
        decimal NewRate,
        DateTime EffectiveDate) : ISyncDomainEvent;
}
