using DataVance.Domain.Common;
using DataVance.Domain.ItemSystem.Entities;
using DataVance.Domain.Warehousing.Setup.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Warehousing.Movements.PurchaseSystem
{
    public class PurchaseReceiptLine : BaseBranchEntity
    {
        public Guid PurchaseReceiptId { get; private set; }

        public Guid ItemId { get; private set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; private set; } = null!;
        public Guid WarehouseId { get; private set; }
        public Guid UnitId { get; private set; }

        // الكمية والأسعار
        public decimal Quantity { get; private set; }
        public decimal UnitCost { get; private set; }

        // ملاحظه هل يتم تخزين الكمية بوحدة الشراء ام بوحدة المخزون ؟
        public decimal ConversionFactor { get; private set; }

        public decimal DiscountAmountForUnit { get; private set; }

        public decimal DiscountAmountForAllQty => (Quantity) * DiscountAmountForUnit;


        public decimal TotalCost => Quantity * UnitCost;
        public decimal NetAmount => TotalCost - DiscountAmountForAllQty;



        public decimal TotalTax => _taxes.Sum(x => x.Amount);

        public decimal TotalAmount => NetAmount + TotalTax;

        // بيانات المخزون المتقدمة
        public string? BatchNumber { get; private set; }
        public DateTime? ExpiryDate { get; private set; }

        private readonly List<LinkTax> _taxes = new();
        public IReadOnlyCollection<LinkTax> Taxes => _taxes.AsReadOnly();



        //public virtual List<LinkTax> TaxSummaries { get; set; } = new();
        //public decimal TotalTax => TaxSummaries.Sum(x => x.Amount);
        internal PurchaseReceiptLine() { } // للمحرك (EF Core)


        public PurchaseReceiptLine(
            Guid purchaseReceiptId,
            Guid itemId,
            Guid warehouseId,
            Guid unitId,
            decimal quantity,
            decimal unitCost,
            decimal conversionFactor,
            string? batchNo,
            DateTime? expiry
         )
        {
            Id = Guid.NewGuid();
            PurchaseReceiptId = purchaseReceiptId;
            ItemId = itemId;
            //WarehouseId = warehouseId;
            UnitId = unitId;
            Quantity = quantity;
            UnitCost = unitCost;
            ConversionFactor = conversionFactor;
            BatchNumber = batchNo;
            ExpiryDate = expiry;

        }

        public void AddTax(LinkTax tax)
        {
            // يمكنك إضافة قواعد تحقق هنا مستقبلاً (Validation)
            _taxes.Add(tax);
        }
    }
}

