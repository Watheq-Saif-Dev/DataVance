using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.Queries
{
    public record GetNextAccountCodeQuery(Guid? ParentId) : IRequest<string>;
}

