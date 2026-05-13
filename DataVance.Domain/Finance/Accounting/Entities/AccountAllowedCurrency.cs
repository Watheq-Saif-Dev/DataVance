using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Accounting.Entities
{
    public class AccountAllowedCurrency : Entity
    {
        public Guid OperationId { get; private set; }
        public Guid CurrencyId { get; private set; }

        private AccountAllowedCurrency() { } // لـ EF Core

        public AccountAllowedCurrency(Guid accountId, Guid currencyId)
        {
            OperationId = accountId;
            CurrencyId = currencyId;
        }
    }
}

