using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.AlertServices
{
    public interface IStatusMessageService
    {
        event Action<string, bool> OnMessageReceived;
        event Action<bool> OnLoadingStateChanged;
        void SetLoadingState(bool isLoading);
        void ShowMessage(string message, bool isError = false);
    }
}


