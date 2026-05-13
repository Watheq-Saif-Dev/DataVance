using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Service
{
    public interface IEventAuthorizationService
    {
        Task<bool> AuthorizeAsync(Guid? userId, string eventCode);

    }
}
