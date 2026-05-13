namespace DataVance.Domain.Finance.Rules.Enums
{

    public enum MapPurpose
    {
        Inventory,               // مخزون
        CostOfGoodsSold,         // تكلفة المبيعات
        SalesRevenue,            // إيرادات المبيعات
        SalesReturn,             // مردودات مبيعات
        PurchaseAccount,         // مشتريات
        PurchaseReturn,          // مردودات مشتريات
        Tax,                     // ضرائب
        AccountPayable,          // موردين (ذمم دائنة)
        AccountReceivable,       // عملاء (ذمم مدينة)
        CashAccount,             // صناديق
        BankAccount,             // بنوك
        DiscountAllowed,         // خصم مسموح به
        DiscountReceived,        // خصم مكتسب
        ExchangeRateDifference   // فروق العملة
    }

}
