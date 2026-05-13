using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface ICurrentUserContext
    {
        Guid BranchId { get; }
        string BranchName { get; }
        string? UserName { get; }
        Guid UserId { get; }
        bool IsAuthenticated { get; }

        string? IpAddress { get; }
        string? DeviceName { get; }
        string? UserAgent { get; }
        public event Func<Task>? OnChangeAsync;
    }
}

