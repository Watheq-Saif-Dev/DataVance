using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.Accounts.DTOs
{
    public record AccountDto(
         Guid Id,
         string Code,
         string Name,
         int Type);
}


