using DataVance.Domain.Common;
using DataVance.Domain.Warehousing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Warehousing.Inventory
{
    public class InventoryMovement : Entity
    {
        // الربط التنظيمي
        public Guid BranchId { get; private set; }
        public Guid WarehouseId { get; private set; }
        public Guid ItemId { get; private set; }

        // بيانات الحركة
        public MovementType Type { get; private set; }
        public DateTime MovementDate { get; private set; }

        // المرجعية (رقم الفاتورة أو رقم السند الذي تسبب في الحركة)
        public string DocumentNo { get; private set; } = null!;
        public Guid DocumentId { get; private set; } // ID الفاتورة الأصلي

        // الكميات (السر هنا!)
        public decimal Quantity { get; private set; } // الكمية بالوحدة التي أُدخلت (مثلاً 1 كرتون)
        public Guid UnitId { get; private set; }      // الوحدة المستخدمة
        public decimal ConversionFactor { get; private set; } // المعامل وقت الحركة (لحماية البيانات التاريخية)

        // الكمية الصافية بالوحدة الأساسية (للحسابات البرمجية)
        public decimal BaseQuantity => Quantity * ConversionFactor;

        public string? BatchNumber { get; private set; }
        public DateTime? ExpiryDate { get; private set; }

        // التكاليف (ضرورية لتقييم المخزون والارباح)
        public decimal UnitCost { get; private set; } // تكلفة الوحدة وقت الحركة
        public decimal TotalCost => BaseQuantity * UnitCost;

        // لربط الحركة بالمستخدم والتدقيق
        public Guid UserId { get; private set; }
        public string? Remarks { get; private set; }


        private InventoryMovement() { }

        public InventoryMovement(
            Guid branchId,
            Guid warehouseId,
            Guid itemId,
            string? batchNumber,
            DateTime? expiryDate,
            MovementType type,
            string documentNo,
            Guid documentId,
            decimal quantity,
            Guid unitId,
            decimal conversionFactor,
            decimal unitCost,
            Guid userId,
            string? remarks = null)
        {
            Id = Guid.NewGuid();
            BranchId = branchId;
            WarehouseId = warehouseId;
            ItemId = itemId;
            BatchNumber = batchNumber;
            ExpiryDate = expiryDate;
            Type = type;
            MovementDate = DateTime.UtcNow;
            DocumentNo = documentNo;
            DocumentId = documentId;
            Quantity = quantity;
            UnitId = unitId;
            ConversionFactor = conversionFactor;
            UnitCost = unitCost;
            UserId = userId;
            Remarks = remarks;
        }
    }
}

