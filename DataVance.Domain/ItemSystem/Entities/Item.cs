using DataVance.Domain.Common;
using DataVance.Domain.ItemSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.Entities
{
    public class Item : AggregateRoot
    {
        public string Code { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public ItemType Type { get; private set; }
        public CostingMethod CostMethod { get; private set; }


        public Guid ItemGroupId { get; private set; }
        public virtual ItemGroup ItemGroup { get; private set; } = null!;

        // الوحدات
        private readonly List<ItemUnit> _units = new();
        public IReadOnlyCollection<ItemUnit> Units => _units.AsReadOnly();
        public ItemUnit? BaseUnit => _units.FirstOrDefault(u => u.IsBaseUnit);


        // آخر متوسط تكلفة (للعرض السريع في التقارير)
        public decimal CurrentCost { get; private set; }
        public decimal LastPurchasePrice { get; private set; }



        public string? Brand { get; private set; }
        public decimal? Weight { get; private set; }
        public string? WeightUnit { get; private set; }
        public bool RequireBatchAndExpiry { get; private set; }
        public bool IsStockable => Type == ItemType.Stocked;

        //  للتحقق من حد إعادة الطلب

        public decimal ReorderPoint { get; private set; } //  إعادة الطلب
        public bool IsActive { get; private set; }


        private Item() { }


        public Item(string code, string name, ItemType type, Guid itemGroupId, decimal currentCost, decimal lastPurchasePrice, Guid baseUnitId, string? baseBarcode = null, CostingMethod costMethod = CostingMethod.WeightedAverage)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Type = type;
            ItemGroupId = itemGroupId;
            //BaseUnitName = baseUnitName;
            CostMethod = costMethod;
            IsActive = true;
            CurrentCost = currentCost;
            LastPurchasePrice = lastPurchasePrice;
            AddBaseUnit(baseUnitId, baseBarcode);
        }
        private void AddBaseUnit(Guid baseUnitId, string? barcode)
        {
            var baseUnit = new ItemUnit(Id, baseUnitId, 1m, true, true, true, barcode);
            _units.Add(baseUnit);
        }
        // دالة إضافة وحدة قياس فرعية (مثلاً: كرتون يحتوي على 12 حبة)
        //public void AddSubUnit(string unitName, decimal conversionFactor, bool isSalesUnit, bool isPurchaseUnit, bool isBase)
        //{
        //    if (conversionFactor <= 1) throw new ArgumentException("Conversion factor must be greater than one");
        //    //if (_units.Any(u => u.UnitName == unitName)) throw new InvalidOperationException("Unit already exists");
        //    if (_units.Any(u => u.UnitName.Equals(unitName, StringComparison.OrdinalIgnoreCase)))
        //        throw new InvalidOperationException("This unit name already exists for this item");

        //    _units.Add(new ItemUnit(Id, unitName, conversionFactor, isSalesUnit, isPurchaseUnit,false));
        //}
        public void AddSubUnit(Guid globalUnitId, decimal conversionFactor, bool isSalesUnit, bool isPurchaseUnit, string? barcode = null)
        {
            if (conversionFactor <= 1)
                throw new ArgumentException("معامل التحويل للوحدة الفرعية يجب أن يكون أكبر من 1");

            if (_units.Any(u => u.GlobalUnitId == globalUnitId))
                throw new InvalidOperationException("هذه الوحدة مضافة مسبقاً لهذا الصنف");

            _units.Add(new ItemUnit(Id, globalUnitId, conversionFactor, false, isSalesUnit, isPurchaseUnit, barcode));
        }

        public void SetStockSettings(decimal reorderPoint, bool requireBatchAndExpiry)
        {
            ReorderPoint = reorderPoint;
            RequireBatchAndExpiry = requireBatchAndExpiry;
        }
        public void UpdateGroup(Guid itemGroupId)
        {
            ItemGroupId = itemGroupId;
        }
        public bool IsBelowReorderPoint(decimal currentQty)
            => IsActive && IsStockable && currentQty <= ReorderPoint;

        public void UpdateCost(decimal newCost, bool isPurchase = true)
        {
            CurrentCost = newCost;
            if (isPurchase) LastPurchasePrice = newCost;
        }
    }
}

