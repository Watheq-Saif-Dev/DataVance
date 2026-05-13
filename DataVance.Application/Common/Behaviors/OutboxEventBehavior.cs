using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Entities.EventSystem;
using MediatR;
using System.Text.Json;

namespace DataVance.Application.Common.Behaviors
{
    public class OutboxEventBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserContext _user;

        public OutboxEventBehavior(IApplicationDbContext context, ICurrentUserContext user)
        {
            _context = context;
            _user = user;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            var response = await next();
            if (typeof(TRequest).Name.EndsWith("Command"))
            {
                var operationMessage = new OutboxMessage(
                    type: typeof(TRequest).Name,
                    content: JsonSerializer.Serialize(request),
                    targetType: OutboxTargetType.Operation,
                    userId: _user.UserId,
                    userEmail: _user.UserName,
                    isFromDomain: false
                );
                _context.OutboxMessages.Add(operationMessage);
            }

            return response;
        }

    }
}


