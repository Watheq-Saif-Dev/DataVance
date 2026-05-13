using DataVance.Domain.Finance.PaymentMethods;
using System.ComponentModel.DataAnnotations;

namespace DataVance.Components.Common.Business.ModelDesgin
{

    public class PurchaseReceiptViewModel
    {
        [Required(ErrorMessage = "رقم الفاتورة مطلوب")]
        public string ReceiptNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "يرجى اختيار المورد")]
        public Guid VendorId { get; set; }

        public string VendorName { get; set; } = string.Empty;

        [Required]
        public DateTime ReceiptDate { get; set; } = DateTime.Now;



        [Required]
        public Guid BranchId { get; set; }

        [Required(ErrorMessage = "المستودع الافتراضي مطلوب")]
        public Guid DefaultWarehouseId { get; set; }

        public string WarehouseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "يرجى اختيار العملة")]
        public Guid CurrencyId { get; set; }

        public string CurrCode { get; set; } = "YER";

        [Range(0.00001, 1000000, ErrorMessage = "سعر الصرف يجب أن يكون أكبر من صفر")]
        public decimal ExchangeRate { get; set; } = 1;
        [MinLength(1, ErrorMessage = "يجب إضافة صنف واحد على الأقل")]
        public List<ReceiptItemDtoViewModel> Items { get; set; } = new();

        public string Notes { get; set; } = string.Empty;

        [Range(0, 999999, ErrorMessage = "قيمة الخصم الإجمالي غير صالحة")]
        public decimal HeaderDiscount { get; set; }

        public List<TaxSummaryViewModel> TaxSummaries { get; set; } = new();



        [Required(ErrorMessage = "يرجى اختيار طريقة الدفع")]
        public PaymentMethodType PaymentMethod { get; set; } = PaymentMethodType.Cash;

        public Guid? FinancialAccountId { get; set; }

        public string? FinancialAccountName { get; set; }

        public string? PaymentReferenceNo { get; set; }

        public decimal TotalCost => Items.Sum(x => x.TotalBeforeDiscount);
        public decimal TotalLineDiscount => Items.Sum(x => x.DiscountAmountForAllQty);
        public decimal NetAmount => TotalCost - TotalLineDiscount - HeaderDiscount;
        public decimal TotalTax => Items.Sum(x => x.TotalTax) + TaxSummaries.Sum(x => x.Amount);
        public decimal TotalLocal => NetAmount + TotalTax;
        public decimal TotalForeign => ExchangeRate > 1 ? TotalLocal / ExchangeRate : TotalLocal;

    }

}


