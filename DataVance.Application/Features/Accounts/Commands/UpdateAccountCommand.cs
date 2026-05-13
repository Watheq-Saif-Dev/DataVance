using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Commands
{
    public record UpdateAccountCommand(
         Guid Id,
         string Name,
         bool AllowPosting
     ) : IRequest<bool>;
}

