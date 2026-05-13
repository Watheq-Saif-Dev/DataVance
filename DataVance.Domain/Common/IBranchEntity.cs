using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Common
{
    public interface IBranchEntity
    {
        Guid BranchId { get; }
        void SetBranchId(Guid branchId);
    }
}
