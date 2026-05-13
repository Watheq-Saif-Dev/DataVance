using DataVance.Application.Common.Events;
using DataVance.Domain.Warehousing.Setup.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Warehouses.Handlers
{
    public class WarehouseAuditHandler : INotificationHandler<SystemEventNotification>
    {

        public async Task Handle(SystemEventNotification notification, CancellationToken ct)
        {
            if (notification.EventCode != "SendWhatsAppOnCreate")
                return;

            try
            {
                var warehouse = JsonSerializer.Deserialize<Warehouse>(notification.PayloadJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (warehouse != null)
                {
                    Console.WriteLine($"?EVENT IS WORKER CREATEWAREHOUSE: {warehouse.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? ERROR TO OPEN JASON DATA: {ex.Message}");
            }
        }
    }
}



