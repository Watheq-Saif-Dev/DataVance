using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Commands;
using MediatR;

namespace DataVance.Application.Security.Handler
{
    public class LoginHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IIdentityService _identityService;
        private readonly IPublisher _publisher;

        public LoginHandler(IIdentityService identityService, IPublisher publisher)
        {
            _identityService = identityService;
            _publisher = publisher;
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken ct)
        {
            var success = await _identityService.LoginAsync(request.Email, request.Password, request.BranchId);

            if (success)
            {
            }

            return success;
        }
    }
}

