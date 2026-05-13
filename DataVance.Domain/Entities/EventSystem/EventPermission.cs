using DataVance.Domain.Common;
using DataVance.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.EventSystem
{
    public class EventPermission : BaseEntity
    {
        public Guid TargetId { get; private set; }
        public PermissionTarget TargetType { get; private set; }

        public Guid SystemEventId { get; private set; }
        public SystemEvent Event { get; private set; } = null!;

        public Guid? BranchId { get; private set; }
        public Guid? WarehouseId { get; private set; }

        public bool IsGranted { get; private set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxAmount { get; private set; } // مرونة إضافية


        private EventPermission() { }

        public EventPermission(Guid targetId, PermissionTarget targetType, Guid systemEventId, Guid? warehouseId, Guid? branchId, bool isGranted, decimal? maxAmount = null)
        {
            Id = Guid.NewGuid();
            TargetId = targetId;
            TargetType = targetType;
            SystemEventId = systemEventId;

            BranchId = branchId;
            WarehouseId = warehouseId;
            IsGranted = isGranted;
            //MaxAmount = maxAmount;
            SetMaxAmount(maxAmount);
        }

        public void Grant() => IsGranted = true;
        //public void Revoke() => IsGranted = false;
        public void Revoke()
        {
            IsGranted = false;
            MaxAmount = null; // قاعدة: إذا سُحبت الصلاحية يصفّر المبلغ تلقائياً
        }
        //public void SetMaxAmount(decimal? maxAmount) => MaxAmount = maxAmount;
        public void SetMaxAmount(decimal? maxAmount)
        {
            if (maxAmount.HasValue && maxAmount.Value < 0)
                throw new ArgumentException("Max amount cannot be negative.");

            MaxAmount = maxAmount;
        }
        public void UpdateLocation(Guid? branchId, Guid? warehouseId)
        {
            BranchId = branchId;
            WarehouseId = warehouseId;
        }
    }
}
