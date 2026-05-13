using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MediatR;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Application.Common.Events;

namespace DataVance.Infrastructure.EventManagement.Services
{
    public class OperationEventExecutor : IOperationEventExecutor
    {

        private readonly IApplicationDbContext _context;
        private readonly IEventAuthorizationService _authorizationService;

        private readonly ILogger<OperationEventExecutor> _logger; // إضافة الـ Logger
        private readonly IMediator _mediator;

        public OperationEventExecutor(
            IApplicationDbContext context,
            IEventAuthorizationService authorizationService,

            ILogger<OperationEventExecutor> logger,
            IMediator mediator)
        {
            _context = context;
            _authorizationService = authorizationService;

            _logger = logger;
            _mediator = mediator;
        }
        // الوظيفة الأولى: جلب الأحداث المرتبطة بالكومند ووضعها في الأوت بكس
        public async Task GenerateEventsFromOperation(OutboxMessage operationMessage)
        {
            var triggers = await _context.EventTriggers
                .Include(x => x.Event)
                .Where(x => x.IsActive && x.Event.IsActive)
                .Where(x => x.OperationCode == operationMessage.Type || x.OperationCode == "*")
                .ToListAsync();
            _logger.LogInformation("Found {Count} triggers for operation {OpType}", triggers.Count, operationMessage.Type);

            foreach (var trigger in triggers)
            {
                var eventOutbox = new OutboxMessage(trigger.Event.Code!, operationMessage.Content, OutboxTargetType.Event, operationMessage.UserId, operationMessage.UserEmail, operationMessage.IsFromDomain);

                _context.OutboxMessages.Add(eventOutbox);
                _logger.LogInformation("Generated Event: {EventCode}", trigger.Event.Code);
            }
            //await _context.SaveChangesAsync();
        }

        public async Task<bool> ExecuteSpecificEvent(OutboxMessage eventMessage)
        {
            // 1. استثناء أحداث الـ Audit التلقائية من فحص الصلاحيات المعقد
            // لأنها أحداث تقنية ناتجة عن عملية (Operation) تم فحص صلاحيتها بالفعل عند دخول الكومند
            if (eventMessage.IsFromDomain)
            {
                return await PublishToMediator(eventMessage);
            }

            // 2. التحقق من الصلاحية للأحداث الوظيفية الأخرى (Business Events)
            var isAuthorized = await _authorizationService.AuthorizeAsync(eventMessage.UserId, eventMessage.Type);
            if (!isAuthorized)
            {
                eventMessage.SetError($"Forbidden: Permission missing for {eventMessage.Type}");
                eventMessage.MarkAsProcessed();
                return false;
            }

            return await PublishToMediator(eventMessage);
        }

        private async Task<bool> PublishToMediator(OutboxMessage eventMessage)
        {
            try
            {
                await _mediator.Publish(new SystemEventNotification(eventMessage.Type, eventMessage.Content, eventMessage.UserId, eventMessage.UserEmail));
                return true;
            }
            catch (Exception ex)
            {
                eventMessage.SetError(ex.Message);
                throw; // لعمل Retry
            }
        }
    }
}
