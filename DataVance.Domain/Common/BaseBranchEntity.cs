using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Common
{
    public abstract class BaseBranchEntity : AggregateRoot, IBranchEntity
    {
        public Guid BranchId { get; protected set; }

        public void SetBranchId(Guid branchId)
        {
            if (BranchId == Guid.Empty)
                BranchId = branchId;
        }
    }
}
