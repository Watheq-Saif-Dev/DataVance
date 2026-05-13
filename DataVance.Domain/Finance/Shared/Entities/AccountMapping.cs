using DataVance.Domain.Common;
using DataVance.Domain.Finance.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Shared.Entities
{

    public class AccountMapping : BaseBranchEntity
    {
        // 1. الوظيفة المحاسبية (التي تأتي من الـ AccountingRuleLine)
        public AccountSourceType AccountSourceType { get; private set; }

        public MapPurpose Purpose { get; private set; }

        public Guid? ReferenceId { get; private set; }

        public Guid? WarehouseId { get; private set; }
        public Guid? TaxId { get; private set; }

        // 3. الحساب المالي النهائي
        public Guid AccountId { get; private set; }


        private AccountMapping() { }

        public AccountMapping(MapPurpose purpose, AccountSourceType sourceType, Guid? referenceId, Guid accountId)
        {
            Purpose = purpose;
            AccountSourceType = sourceType;
            ReferenceId = referenceId;
            AccountId = accountId;
        }

        // 1. المشتريات والموردين
        public static AccountMapping ForVendor(Guid vendorId, Guid chartOfAccountId)
            => new(MapPurpose.AccountPayable, AccountSourceType.Vendor, vendorId, chartOfAccountId);

        // 2. المبيعات والعملاء
        public static AccountMapping ForCustomer(Guid customerId, Guid chartOfAccountId)
            => new(MapPurpose.AccountReceivable, AccountSourceType.Customer, customerId, chartOfAccountId);

        // 3. النقدية والبنوك
        public static AccountMapping ForCash(Guid financialAccountId, Guid chartOfAccountId)
            => new(MapPurpose.CashAccount, AccountSourceType.FinancialAccount, financialAccountId, chartOfAccountId);

        public static AccountMapping ForBank(Guid financialAccountId, Guid chartOfAccountId)
            => new(MapPurpose.BankAccount, AccountSourceType.FinancialAccount, financialAccountId, chartOfAccountId);

        // 4. المخزون والضرائب
        public static AccountMapping ForWarehouse(Guid warehouseId, Guid chartOfAccountId)
            => new(MapPurpose.Inventory, AccountSourceType.Warehouse, warehouseId, chartOfAccountId);

        public static AccountMapping ForTax(Guid taxId, Guid chartOfAccountId)
            => new(MapPurpose.Tax, AccountSourceType.TaxCode, taxId, chartOfAccountId);

        // 5. ثوابت النظام (الخصومات وفروق العملة)
        public static AccountMapping ForSystemAccount(MapPurpose purpose, Guid chartOfAccountId)
            => new(purpose, AccountSourceType.System, null, chartOfAccountId);
    }
}
