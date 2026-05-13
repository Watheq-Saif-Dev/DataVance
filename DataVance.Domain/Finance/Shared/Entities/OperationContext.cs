using DataVance.Domain.Common;
using DataVance.Domain.Entities.BranchSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Shared.Entities
{
    public class OperationContext
    {

        public Guid CurrencyId { get; private set; }
        public decimal ExchangeRate { get; private set; }
        public string CurrencyCode { get; private set; } = "";

        private OperationContext() { }

        public OperationContext(Guid currencyId, decimal exchangeRate, string currencyCode)
        {
            // التحقق من القيم (Validation)
            //if (branchId == Guid.Empty) throw new ArgumentException("Branch is required");

            //BranchId = branchId;
            CurrencyId = currencyId;
            ExchangeRate = exchangeRate;
            CurrencyCode = currencyCode;
        }
    }

}
