using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Accounts.Commands;
using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Shared.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken ct)
        {
            var codeExists = await _context.Accounts
                .AnyAsync(a => a.Code == request.Code, ct);

            if (codeExists)
            {
                throw new Exception($"رقم الحساب '{request.Code}' موجود مسبقاً في الدليل.");
            }

            var account = new Account(
                            request.Code,
                            request.Name,
                            (AccountType)request.Type,
                            request.ParentId
                              );
            if (!request.AllowPosting)
            {
                account.SetAsParent();
            }
            if (request.DefaultCurrencyId.HasValue)
            {
                account.SetDefaultCurrency(request.DefaultCurrencyId.Value);
            }
            if (request.AllowedCurrencyIds != null && request.AllowedCurrencyIds.Any())
            {
                foreach (var currencyId in request.AllowedCurrencyIds)
                {
                    account.AddAllowedCurrency(currencyId);
                }
            }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(ct);

            return account.Id;
        }
    }
}



