using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IAccountMappingResolver
    {
        Task<Guid> ResolveAccountAsync(MapPurpose purpose, AccountSourceType sourceType, Guid? referenceId = null);
        Task<Guid> GetVendorAccountAsync(Guid vendorId);
        Task<Guid> GetFinancialAccountAsync(Guid financialAccountId, bool isBank);
        Task<Guid> GetInventoryAccountAsync(Guid warehouseId);
        Task<Guid> GetByAccountAsync(Guid accountId);
    }
}

