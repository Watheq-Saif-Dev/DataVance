using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Accounts.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Handlers
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken ct)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Id == request.Id, ct);

            if (account == null) throw new Exception("الحساب غير موجود.");
            account.Rename(request.Name);

            if (request.AllowPosting)
            {
                account.SetAsChild();
            }
            else
            {
                account.SetAsParent();
            }

            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}



