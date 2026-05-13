using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.TaxSystem
{
    public class BranchTaxSetting : BaseBranchEntity
    {
        public Guid TaxCodeId { get; private set; }
        public virtual TaxCode TaxCode { get; private set; } = null!;

        public string? LocalTaxNumber { get; private set; } // رقم ضريبي خاص بالفرع
        //public Guid TaxAccountId { get; private set; }     // الحساب المالي لهذا الفرع
        public bool IsActiveInBranch { get; private set; } // هل هذه الضريبة متاحة لهذا الفرع؟

        protected BranchTaxSetting() { }

        public BranchTaxSetting(Guid branchId, Guid taxCodeId, string? taxNumber = null)
        {
            BranchId = branchId;
            TaxCodeId = taxCodeId;
            //TaxAccountId = taxAccountId;
            LocalTaxNumber = taxNumber;
        }



    }
}
