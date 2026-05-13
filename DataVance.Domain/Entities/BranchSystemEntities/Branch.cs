using DataVance.Domain.Common;
using DataVance.Domain.Warehousing.Enums;
using DataVance.Domain.Warehousing.Setup.Entities;


namespace DataVance.Domain.Entities.BranchSystem
{

    public class Branch : AggregateRoot
    {
        public string Name { get; private set; } = null!;
        public string Code { get; private set; } = null!; // مثال: "BR-ADN-01"

        // 1. الربط المالي والمحاسبي (السر الحقيقي للـ ERP)
        public Guid? CostCenterId { get; private set; } // مركز التكلفة الخاص بالفرع
        public Guid? BaseCurrencyId { get; private set; } // العملة الأساسية للفرع

        // 2. بيانات قانونية للطباعة
        public string? TaxNumber { get; private set; }
        public string? Address { get; private set; }

        // 3. هيكلية الفروع (للشركات الكبرى)
        public Guid? ParentBranchId { get; private set; }
        public bool IsHeadquarters { get; private set; }

        public bool IsActive { get; private set; }

        // إدارة المخازن التابعة للفرع
        private readonly List<Warehouse> _warehouses = new();
        public IReadOnlyCollection<Warehouse> Warehouses => _warehouses.AsReadOnly();

        private Branch() { } // For EF Core

        public Branch(string name, string code, Guid? baseCurrencyId, bool isHeadquarters = false)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is required");

            Id = Guid.NewGuid();
            Name = name;
            Code = code;
            BaseCurrencyId = baseCurrencyId;
            IsHeadquarters = isHeadquarters;
            IsActive = true;
        }

        // دالة احترافية لإضافة مخزن مع تحديد نوعه وربطه المحاسبي
        public Warehouse AddWarehouse(string name, string location, WarehouseType type, Guid? inventoryAccountId = null)
        {
            if (_warehouses.Any(w => w.Name == name))
                throw new InvalidOperationException($"Warehouse '{name}' already exists in this branch.");

            var warehouse = new Warehouse(Id, name, location, type, inventoryAccountId);
            _warehouses.Add(warehouse);
            return warehouse; // نعيد الكيان لمن يحتاجه بعد الإنشاء
        }

        public void AssignCostCenter(Guid costCenterId)
        {
            CostCenterId = costCenterId;
        }

        public void UpdateLegalDetails(string taxNumber, string address)
        {
            TaxNumber = taxNumber;
            Address = address;
        }

        public void ToggleStatus() => IsActive = !IsActive;
    }
}

