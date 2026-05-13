using DataVance.Domain.Warehousing.Enums;

namespace DataVance.Application.Features.PurchaseTransactions.DTO
{
    public record TransferRequest(
        Guid BranchId, Guid FromWarehouseId, Guid ToWarehouseId,
        Guid ItemId, Guid UnitId, decimal Quantity, decimal ConversionFactor,
        decimal UnitCost, string DocumentNo, Guid DocumentId, Guid UserId,
        string? BatchNumber = null, DateTime? ExpiryDate = null
    )
    {
        public InventoryRequest ToInventoryRequest(Guid warehouseId, MovementType type)
            => new(BranchId, warehouseId, ItemId, UnitId, Quantity, ConversionFactor, UnitCost, type, DocumentNo, DocumentId, UserId, BatchNumber, ExpiryDate);
    }
}

