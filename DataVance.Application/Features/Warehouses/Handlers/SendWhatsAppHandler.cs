using DataVance.Application.Common.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Handlers
{
    public class SendWhatsAppHandler : INotificationHandler<SystemEventNotification>
    {
        public async Task Handle(SystemEventNotification notification, CancellationToken ct)
        {
            if (notification.EventCode != "SendWhatsAppOnCreate") return;
            var warehouseName = notification.PayloadJson?.ToString();

            if (!string.IsNullOrEmpty(warehouseName))
            {
                Console.WriteLine($"? [WhatsApp] Sending notification for: {warehouseName}");
            }
            else
            {
                Console.WriteLine("? [WhatsApp] Failed: No warehouse data found in notification.");
            }
        }
    }
}


