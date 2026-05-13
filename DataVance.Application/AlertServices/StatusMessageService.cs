using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AlertServices
{
    public class StatusMessageService : IStatusMessageService
    {
        public event Action<string, bool>? OnMessageReceived;
        public event Action<bool> OnLoadingStateChanged;
        public void SetLoadingState(bool isLoading) => OnLoadingStateChanged?.Invoke(isLoading);
        public void ShowMessage(string message, bool isError = false)
        => OnMessageReceived?.Invoke(message, isError);

    }
}

