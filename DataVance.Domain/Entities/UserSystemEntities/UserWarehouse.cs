using DataVance.Domain.Common;
using DataVance.Domain.Warehousing.Setup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.UserSystem
{
    public class UserWarehouse : BaseBranchEntity
    {
        public Guid UserId { get; set; }

        public Guid WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; } = null!;

    }
}
