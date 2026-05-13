using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.ItemSystem.ItemEntity
{
    public record StockReachedReorderPointEvent(
    Guid ItemId,
    Guid WarehouseId,
    decimal CurrentQuantity,
    decimal ReorderPoint) : IDomainEvent;
}
