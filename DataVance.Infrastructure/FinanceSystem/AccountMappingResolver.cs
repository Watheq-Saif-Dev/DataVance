using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class AccountMappingResolver : IAccountMappingResolver
    {
        private readonly ApplicationDbContext _mappingRepo; // افترض أن لديك مستودع للبيانات

        public AccountMappingResolver(ApplicationDbContext context)
        {
            _mappingRepo = context;
        }

        public async Task<Guid> ResolveAccountAsync(MapPurpose purpose, AccountSourceType sourceType, Guid? referenceId = null)
        {

            var accountId = await _mappingRepo.AccountMappings
                .AsNoTracking()
                .Where(x => x.Purpose == purpose &&
                            x.AccountSourceType == sourceType &&
                            x.ReferenceId == referenceId)
                .Select(x => x.AccountId)
                .FirstOrDefaultAsync();


            if (accountId == Guid.Empty)
            {
                throw new InvalidOperationException(
                    $"[Accounting Error]: Missing mapping for Purpose: {purpose}, " +
                    $"Source: {sourceType}, Reference: {referenceId ?? Guid.Empty}. " +
                    "الرجاء ضبط توجيه الحسابات قبل إتمام العملية.");
            }

            return accountId;
        }

        public async Task<Guid> GetVendorAccountAsync(Guid vendorId)
        {
            return await ResolveAccountAsync(MapPurpose.AccountPayable, AccountSourceType.Vendor, vendorId);
        }

        public async Task<Guid> GetFinancialAccountAsync(Guid financialAccountId, bool isBank)
        {
            var purpose = isBank ? MapPurpose.BankAccount : MapPurpose.CashAccount;
            return await ResolveAccountAsync(purpose, AccountSourceType.FinancialAccount, financialAccountId);
        }

        public async Task<Guid> GetInventoryAccountAsync(Guid warehouseId)
        {
            return await ResolveAccountAsync(MapPurpose.Inventory, AccountSourceType.Warehouse, warehouseId);
        }
        public async Task<Guid> GetByAccountAsync(Guid accountId)
        {
            return await ResolveAccountAsync(MapPurpose.AccountPayable, AccountSourceType.Payable, accountId);
        }
    }
}
