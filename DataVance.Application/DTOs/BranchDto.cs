using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.DTOs
{
    public record BranchDto(Guid Id, string Name, string Code);
}
