using DataVance.Domain.Entities.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Service
{

    public interface IOperationEventExecutor
    {
        Task<bool> ExecuteSpecificEvent(OutboxMessage eventMessage);
        Task GenerateEventsFromOperation(OutboxMessage operationMessage);
    }
}
