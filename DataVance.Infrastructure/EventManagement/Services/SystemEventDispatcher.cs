using DataVance.Application.Security.Commands;
using DataVance.Application.Security.Handler;
using DataVance.Application.Security.Service;
using MediatR;

namespace DataVance.Infrastructure.EventManagement.Services
{
    //public class SystemEventDispatcher : ISystemEventDispatcher
    //{
    //    private readonly IMediator _mediator;

    //    public SystemEventDispatcher(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    public async Task DispatchAsync(string eventCode, object context)
    //    {
    //        var notification = new SystemEventNotification(eventCode, context);
    //        await _mediator.Publish(notification);
    //    }
    //}


    //public class SystemEventDispatcher : ISystemEventDispatcher
    //{
    //    private readonly IPublisher _publisher;
    //    private readonly ILogger<SystemEventDispatcher> _logger; // من الجيد دائماً إضافة Logger لتتبع الإشعارات

    //    public SystemEventDispatcher(IPublisher publisher, ILogger<SystemEventDispatcher> logger)
    //    {
    //        _publisher = publisher;
    //        _logger = logger;
    //    }
    //    public async Task DispatchAsync(string eventCode, string payloadJson, CancellationToken cancellationToken = default)
    //    {
    //        _logger.LogInformation("📢 جاري نشر الإشعار للحدث: {EventCode}", eventCode);

    //        // تغليف الكود والبيانات في إشعار واحد
    //        var notification = new SystemEventNotification(eventCode, payloadJson);

    //        // إطلاق الإشعار لجميع المستمعين (Handlers) وتمرير الـ CancellationToken
    //        await _publisher.Publish(notification, cancellationToken);
    //    }
    //public async Task DispatchAsync(string eventCode, string payloadJson)
    //{
    //    // تغليف كود الحدث والبيانات (JSON) في إشعار واحد
    //    var notification = new SystemEventNotification(eventCode, payloadJson);

    //    // إطلاق الإشعار لجميع المستمعين (Handlers) في النظام
    //    await _publisher.Publish(notification);
    //}
}
//}

