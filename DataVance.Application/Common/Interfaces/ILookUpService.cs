using DataVance.Domain.Finance.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface ILookUpService
    {
        Task<List<LookupItem>> GetCurrencyLookup(Guid? AccountId, string? filter = null);
        Task<List<LookupItem>> GetVendorLookup();
        Task<List<LookupItem>> GetItemsLookup(
                string? searchTerm,
                Guid? itemGroupId = null,
                Guid? warehouseId = null,
                Guid? branchId = null,
                bool onlyWithBalance = false,
                bool isPurchase = false,
                bool isSales = false);
        Task<List<LookupItem>> GetUnitItemLookup(Guid itemId,
            bool isPurchase = false,
            bool isSales = false);
        Task<List<LookupItem>> GetBranchLookup(Guid? userId);
        Task<List<LookupItem>> GetWarehousesLookup(Guid? UserId);
        Task<LookupItem?> GetItemByBarcode(string barcode);
        Task<List<LookupItem>> GetPaymentMethodType(string type);
        Task<List<LookupItem>> GetAccountForPay();

    }
}


