using DataVance.Domain.Common;
using DataVance.Domain.Entities.BranchSystem;
using DataVance.Domain.Warehousing.Enums;

namespace DataVance.Domain.Warehousing.Setup.Entities
{
    //public class Warehouse : BaseEntity 
    //{

    //}
    public class Warehouse : BaseBranchEntity
    {

        public string Name { get; private set; } = null!;
        public string Location { get; private set; } = null!;

        public WarehouseType Type { get; private set; }

        // السر الثاني: حساب المخزون الخاص بهذا المخزن (إن وجد)
        // إذا كان Null، يأخذ النظام حساب المخزون الافتراضي من الـ SystemSettings أو الـ ItemCategory
        public Guid? InventoryAccountId { get; private set; }

        public bool IsActive { get; private set; }

        // Internal لضمان أن الفرع (Root) هو الوحيد الذي يمكنه إنشاء مخزن
        internal Warehouse() { }

        internal Warehouse(Guid branchId, string name, string location, WarehouseType type, Guid? inventoryAccountId)
        {
            Id = Guid.NewGuid();
            BranchId = branchId;
            Name = name;
            Location = location;
            Type = type;
            InventoryAccountId = inventoryAccountId;
            IsActive = true;
        }

        public void UpdateDetails(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public void SetInventoryAccount(Guid accountId)
        {
            InventoryAccountId = accountId;
        }

        public void ToggleStatus() => IsActive = !IsActive;
    }
}

