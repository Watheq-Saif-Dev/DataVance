using DataVance.Domain.Entities.BranchSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.UserSystem
{
    public class UserBranch
    {
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
        public bool IsDefault { get; set; }

    }
}
