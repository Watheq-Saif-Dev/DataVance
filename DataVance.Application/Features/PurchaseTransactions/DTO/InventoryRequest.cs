using DataVance.Domain.Warehousing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.PurchaseTransactions.DTO
{
    public record InventoryRequest(
     Guid BranchId, Guid WarehouseId, Guid ItemId, Guid UnitId,
     decimal Quantity, decimal ConversionFactor, decimal UnitCost,
     MovementType Type, string DocumentNo, Guid DocumentId,
     Guid UserId, string? BatchNumber = null, DateTime? ExpiryDate = null, string? Remarks = null
 );
}


