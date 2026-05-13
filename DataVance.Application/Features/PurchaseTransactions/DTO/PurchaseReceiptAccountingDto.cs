namespace DataVance.Application.Features.PurchaseTransactions.DTO
{
    public record PurchaseReceiptAccountingDto(
    Guid Id,
    string ReceiptNo,
    DateTime ReceiptDate,
    Guid BranchId,
    Guid VendorAccountId,
    Guid WarehouseId,
    decimal TotalAmount,
    Guid CurrencyId,
    decimal ExchangeRate
);
}


