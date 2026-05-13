using DataVance.Domain.Common;
using DataVance.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.EventSystem
{
    public class EventTrigger : BaseEntity
    {
        public string OperationCode { get; private set; } = null!;
        // مثال: CreateInvoiceCommand

        public Guid SystemEventId { get; private set; }
        public SystemEvent Event { get; private set; } = null!;

        public int ExecutionOrder { get; private set; }

        public EventImportance Importance { get; private set; }

        public bool IsActive { get; private set; } = true;

        private EventTrigger() { }

        public EventTrigger(string operationCode, Guid systemEventId, int executionOrder, EventImportance importance)
        {
            Id = Guid.NewGuid();
            Update(operationCode, systemEventId, executionOrder, importance);
            IsActive = true;
        }
        public void Update(string operationCode, Guid systemEventId, int executionOrder, EventImportance importance)
        {
            if (string.IsNullOrWhiteSpace(operationCode))
                throw new ArgumentException("Operation Code cannot be empty.");

            OperationCode = operationCode;
            SystemEventId = systemEventId;
            ExecutionOrder = executionOrder;
            Importance = importance;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;


    }

}
