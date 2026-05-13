namespace DataVance.Domain.Warehousing.Enums
{
    public enum MovementType
    {
        OpeningBalance = 1,    // رصيد أول المدة
        PurchaseReceipt = 2,   // توريد مشتريات
        SalesIssue = 3,        // صرف مبيعات
        StockTransferIn = 4,   // تحويل وارد (من مخزن آخر)
        StockTransferOut = 5,  // تحويل صادر (إلى مخزن آخر)
        AdjustmentIn = 6,      // تسوية جردية (إضافة)
        AdjustmentOut = 7,     // تسوية جردية (خصم)
        ReturnIn = 8,          // مرتجع مبيعات
        ReturnOut = 9          // مرتجع مشتريات
    }
}

