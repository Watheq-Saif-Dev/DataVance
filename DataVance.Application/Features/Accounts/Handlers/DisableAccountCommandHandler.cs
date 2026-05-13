using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Accounts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Handlers
{
    public class DisableAccountCommandHandler : IRequestHandler<DisableAccountCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DisableAccountCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DisableAccountCommand request, CancellationToken ct)
        {
            var account = await _context.Accounts.FindAsync(request.Id);
            if (account == null) return false;

            if (account.IsActive == false)
            {
                account.Activate();
            }
            else
            {
                account.Disable();
            }

            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}

