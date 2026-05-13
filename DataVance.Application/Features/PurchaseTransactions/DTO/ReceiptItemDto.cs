namespace DataVance.Application.Features.PurchaseTransactions.DTO
{

    public class ReceiptItemDto
    {
        public Guid ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public Guid WarehouseId { get; set; }
        public Guid UnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal ConversionFactor { get; set; } = 1;
        public decimal DiscountAmountForUnit { get; set; }
        public string? BatchNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public ReceiptItemDto(Guid itemId, string itmName, Guid waId, Guid uniD, decimal q, decimal unc, decimal cov, decimal discUnit, string btn, DateTime date)
        {
            ItemId = itemId;
            ItemName = itmName;
            WarehouseId = waId;
            UnitId = uniD;
            Quantity = q;
            UnitCost = unc;
            ConversionFactor = cov;
            DiscountAmountForUnit = discUnit;
            BatchNumber = btn;
            ExpiryDate = date;
        }
    }

}


