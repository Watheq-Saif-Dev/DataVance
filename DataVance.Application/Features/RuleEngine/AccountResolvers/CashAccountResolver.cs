using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Domain.Finance.PaymentMethods;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.AccountResolvers
{
    public class CashAccountResolver : IAccountResolver
    {
        public bool IsMatch(AccountSourceType sourceType, PaymentMethodType paymentMethod) =>
            sourceType == AccountSourceType.FinancialAccount && paymentMethod == PaymentMethodType.Cash;


        public async Task<Guid> ResolveAccount(PostingContext context, IAccountMappingResolver mappingRepo, Guid? currentReferenceId = null)
        {
            var id = context.PaymentMethod.FinancialAccountId ?? Guid.NewGuid();
            return await mappingRepo.GetFinancialAccountAsync(id, false);
        }

    }
    public class PayableToCreditResolver : IAccountResolver
    {

        public bool IsMatch(AccountSourceType sourceType, PaymentMethodType paymentMethod) =>
             sourceType == AccountSourceType.Payable && paymentMethod == PaymentMethodType.Credit;

        public async Task<Guid> ResolveAccount(PostingContext context, IAccountMappingResolver mappingRepo, Guid? currentReferenceId = null)
        {

            return await mappingRepo.GetVendorAccountAsync(context.Payable);
        }
    }
    public class PayableToAccountResolver : IAccountResolver
    {

        public bool IsMatch(AccountSourceType sourceType, PaymentMethodType paymentMethod) =>
             sourceType == AccountSourceType.Payable && paymentMethod == PaymentMethodType.Account;

        public async Task<Guid> ResolveAccount(PostingContext context, IAccountMappingResolver mappingRepo, Guid? currentReferenceId = null)
        {
            var id = context.PaymentMethod.FinancialAccountId ?? Guid.NewGuid();

            return await mappingRepo.GetByAccountAsync(id);
        }
    }
    public class InventoryAccountResolver : IAccountResolver
    {

        public bool IsMatch(AccountSourceType sourceType, PaymentMethodType paymentMethod) =>
             sourceType == AccountSourceType.Inventory;


        public async Task<Guid> ResolveAccount(PostingContext context, IAccountMappingResolver mappingRepo, Guid? currentReferenceId = null)
        {
            if (!context.References.TryGetValue(AccountSourceType.Warehouse, out var references) || !references.Any())
            {
                throw new Exception($"Missing reference for {AccountSourceType.Inventory} in Posting Context.");
            }


            var targetRef = references.FirstOrDefault(r => r.AccountSource == AccountSourceType.Warehouse);

            return await mappingRepo.GetInventoryAccountAsync(targetRef!.ReferenceId);
        }

    }

    public class TaxAccountResolver : IAccountResolver
    {
        public bool IsMatch(AccountSourceType sourceType, PaymentMethodType paymentMethod) =>
             sourceType == AccountSourceType.TaxCode;

        public async Task<Guid> ResolveAccount(PostingContext context, IAccountMappingResolver mappingRepo, Guid? currentReferenceId = null)
        {
            if (!context.References.TryGetValue(AccountSourceType.TaxCode, out var references) || !references.Any())
                throw new Exception($"Missing reference for {AccountSourceType.TaxCode} in Posting Context.");

            var targetRef = references.FirstOrDefault(r => r.AccountSource == AccountSourceType.TaxCode);

            return await mappingRepo.ResolveAccountAsync(MapPurpose.Tax, AccountSourceType.TaxCode, currentReferenceId);
        }
    }



}



