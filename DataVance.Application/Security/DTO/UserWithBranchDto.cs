using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.DTO
{
    public record UserWithBranchDto(Guid Id, string Name, List<Guid> AssignedBranchIds);
}
