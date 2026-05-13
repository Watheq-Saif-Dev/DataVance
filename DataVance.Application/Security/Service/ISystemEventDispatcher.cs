using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Service
{

    public interface ISystemEventDispatcher
    {
        Task DispatchAsync(string eventCode, string context, CancellationToken cancellationToken = default);
    }
}
