namespace DataVance.Domain.Finance.Rules.Enums
{
    public enum AccountSourceType
    {
        System,             // ثوابت النظام (مثل فروق العملة)
        Fixed,              // حساب ثابت محدد مسبقاً
        Customer,           // مرتبط بالعميل
        Vendor,             // مرتبط بالمورد
        Warehouse,          // مرتبط بالمستودع
        Category,           // مرتبط بفئة الصنف
        TaxCode,            // مرتبط بنوع الضريبة
        FinancialAccount,    // مرتبط بصندوق أو بنك
        Inventory,          // مرتبط بحساب المخزون
        Payable,            // مرتبط بحساب الموردين (ذمم دائنة)
        DiscountReceived     // مرتبط بحساب الخصم المكتسب

    }

}
