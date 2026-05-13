namespace DataVance.Components.Common.Business.ModelDesgin
{
    public interface IItemTransactionLine
    {
        Guid ItemId { get; set; }
        string ItemName { get; set; }
        Guid WarehouseId { get; set; }
        string WarehouseName { get; set; }
        Guid UnitId { get; set; }
        string UnitName { get; set; }
        decimal Quantity { get; set; }
        decimal UnitPriceOrCost { get; set; }
        decimal UnitPrice { get; set; }
        decimal UnitCost { get; set; }
        decimal ConversionFactor { get; set; }
        string? BatchNumber { get; set; }
        DateTime ExpiryDate { get; set; }
        string Barcode { get; set; }

        decimal DiscountAmountForUnit { get; set; }
        decimal DiscountAmountForAllQty { get; }
        decimal TotalBeforeDiscount { get; }
        decimal NetAmount { get; }
        decimal TotalTax { get; }
        decimal TotalAmount { get; }
    }
}

