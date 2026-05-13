using DataVance.Domain.Common;
using DataVance.Domain.Finance.Rules.Enums;
using System;

namespace DataVance.Domain.Finance.Rules.Events
{
    public record PostToAccountingEvent(Guid ReferenceId, string OperationCode, DateTime EventDate, Guid BranchId) : IDomainEvent
    {
        public DateTime OccurredOn => EventDate;
    }
}
