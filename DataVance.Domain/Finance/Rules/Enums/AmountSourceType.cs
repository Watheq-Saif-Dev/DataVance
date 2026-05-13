namespace DataVance.Domain.Finance.Rules.Enums
{
    public enum AmountSourceType
    {
        FullAmount,      // الإجمالي مع الضريبة
        NetAmount,       // الإجمالي بدون ضريبة
        TaxAmount,       // مبلغ الضريبة (سيتم سحبه من تفاصيل الضرائب في الحدث)
        LineAmount,      // مبلغ السطر
        CostAmount,      // التكلفة (للقيود المخزنية)
        ShippingAmount,   // مبلغ الشحن
        DiscountAmount   // مبلغ الخصم
    }
}
