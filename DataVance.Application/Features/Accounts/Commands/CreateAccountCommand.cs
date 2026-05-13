using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Commands
{
    public record CreateAccountCommand(
         string Code,
         string Name,
         int Type,
         Guid? ParentId,
         bool AllowPosting,
         Guid? DefaultCurrencyId,
         List<Guid> AllowedCurrencyIds
     ) : IRequest<Guid>;
}


