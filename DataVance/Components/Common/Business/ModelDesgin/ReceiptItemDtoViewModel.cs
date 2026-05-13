using System.ComponentModel.DataAnnotations;

namespace DataVance.Components.Common.Business.ModelDesgin
{



    public class ReceiptItemDtoViewModel : IItemTransactionLine
    {
        [Required(ErrorMessage = "يرجى اختيار الصنف")]
        public Guid ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "يرجى تحديد المستودع")]
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "يرجى اختيار الوحدة")]
        public Guid UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }

        [Range(0.01, 999999, ErrorMessage = "الكمية يجب أن تكون أكبر من صفر")]
        public decimal Quantity { get; set; }

        [Range(0, 999999, ErrorMessage = "التكلفة غير صالحة")]
        public decimal UnitCost { get; set; }

        [Range(0, 999999, ErrorMessage = "سعر البيع غير صالح")]
        public decimal UnitPrice { get; set; }

        public decimal ConversionFactor { get; set; }
        public string? BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.Now;

        [Range(0, 999999, ErrorMessage = "قيمة الخصم غير صالحة")]
        public decimal DiscountAmountForUnit { get; set; }

        public decimal DiscountAmountForAllQty => Quantity * DiscountAmountForUnit;
        public decimal TotalBeforeDiscount => Quantity * UnitPriceOrCost;

        public decimal NetAmount => TotalBeforeDiscount - DiscountAmountForAllQty;


        public List<TaxSummaryViewModel> TaxSummaries { get; set; } = new();

        public decimal TotalTax => TaxSummaries.Sum(x => x.Amount);
        public decimal TotalAmount => NetAmount + TotalTax;

        public decimal UnitPriceOrCost
        {
            get => UnitPrice > 0 ? UnitPrice : UnitCost;
            set
            {
                UnitPrice = value;
                UnitCost = value;
            }
        }



    }
    public class TaxSummaryViewModel
    {
        public Guid TaxId { get; set; }
        public string TaxName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}

