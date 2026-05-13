using DataVance.Domain.Common;
using DataVance.Domain.Entities.ItemSystem.ItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Warehousing.Inventory
{
    public class InventoryBalance : AggregateRoot
    {
        public Guid ItemId { get; private set; }
        public Guid WarehouseId { get; private set; }
        public Guid BranchId { get; private set; }

        public decimal Quantity { get; private set; } // دائماً بالوحدة الأساسية (Base Unit)

        public string? BatchNumber { get; private set; } // رقم التشغيلة/الدفعة
        public DateTime? ExpiryDate { get; private set; } // تاريخ الانتهاء


        // لإدارة التكلفة (خاصة في حالة المتوسط المرجح)
        public decimal TotalValue { get; private set; }
        //public decimal AverageCost => Quantity == 0 ? 0 : TotalValue / Quantity;
        public decimal AverageCost => Quantity <= 0 ? 0 : Math.Round(TotalValue / Quantity, 4);
        public byte[] RowVersion { get; private set; }

        // إعدادات إضافية ضرورية للـ ERP
        public decimal ReservedQuantity { get; private set; } // كمية محجوزة (طلبيات لم تخرج بعد)
        public decimal AvailableQuantity => Quantity - ReservedQuantity;

        private InventoryBalance() { }

        public InventoryBalance(Guid itemId, Guid warehouseId, string? batchNumber, DateTime? expiryDate)
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            WarehouseId = warehouseId;
            BatchNumber = batchNumber;
            ExpiryDate = expiryDate;
            Quantity = 0;
            TotalValue = 0;
        }
        public InventoryBalance(Guid itemId, Guid warehouseId, Guid branchId, decimal initialQty, decimal unitCost)
        {
            ItemId = itemId;
            WarehouseId = warehouseId;
            BranchId = branchId;
            Quantity = initialQty;
            TotalValue = initialQty * unitCost;
        }
        public void UpdateBalance(decimal newQuantity, decimal newTotalValue)
        {
            Quantity = newQuantity;
            TotalValue = newTotalValue;
        }
        public void AddStock(decimal baseQty, decimal unitCost)
        {
            Quantity += baseQty;
            TotalValue += baseQty * unitCost;
            // تقريب القيمة الإجمالية لتفادي فوارق الكسور العشرية الطويلة
            TotalValue = Math.Round(TotalValue, 4);
        }
        public void RemoveStock(decimal baseQty, decimal unitCost)
        {
            // صمام أمان: منع السحب بأكثر من المتاح
            if (AvailableQuantity < baseQty) // استخدمنا AvailableQuantity التي خصمنا منها المحجوز
                throw new InvalidOperationException($"الكمية المتاحة غير كافية. المتاح: {AvailableQuantity}");

            // صمام أمان: التأكد من عدم انتهاء الصلاحية عند الصرف (اختياري حسب سياسة الشركة)
            if (ExpiryDate.HasValue && ExpiryDate < DateTime.UtcNow)
                throw new InvalidOperationException("لا يمكن صرف صنف منتهي الصلاحية");

            decimal avgCost = Quantity == 0 ? 0 : TotalValue / Quantity;
            Quantity -= baseQty;
            TotalValue -= baseQty * avgCost;
        }
        public void RemoveStock(decimal baseQty)
        {
            if (AvailableQuantity < baseQty)
                throw new InvalidOperationException($"الكمية غير كافية. المتاح: {AvailableQuantity}");

            // الصرف يتم دائماً بالمتوسط المرجح الحالي
            decimal costToRemove = baseQty * AverageCost;

            Quantity -= baseQty;
            TotalValue -= costToRemove;

            // تنظيف الكسور إذا وصل الرصيد لصفر
            if (Quantity <= 0)
            {
                Quantity = 0;
                TotalValue = 0;
            }
        }
        public void CheckReorderPoint(decimal reorderPoint)
        {
            if (Quantity <= reorderPoint)
            {
                // هنا تستطيع استدعاء الدالة وهي protected لأنك داخل الكيان
                AddDomainEvent(new StockReachedReorderPointEvent(ItemId, WarehouseId, Quantity, reorderPoint));
            }
        }
        public void ReserveStock(decimal qty) => ReservedQuantity += qty;
        public void UnreserveStock(decimal qty) => ReservedQuantity -= qty;
    }
}
