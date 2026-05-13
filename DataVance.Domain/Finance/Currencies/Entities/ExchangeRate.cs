using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataVance.Domain.Finance.Currencies.Entities
{
    public class ExchangeRate : Entity
    {
        //public string FromCurrency { get; private set; }
        //public string ToCurrency { get; private set; }
        public Guid CurrencyId { get; private set; }
        public decimal Rate { get; private set; }
        public DateTime EffectiveDate { get; private set; }

        private ExchangeRate() { }

        public ExchangeRate(Guid currencyId, decimal rate, DateTime date)
        {
            if (rate <= 0) throw new ArgumentException("سعر الصرف يجب أن يكون أكبر من صفر.");

            CurrencyId = currencyId;
            Rate = rate;
            EffectiveDate = date;
        }
    }
}
