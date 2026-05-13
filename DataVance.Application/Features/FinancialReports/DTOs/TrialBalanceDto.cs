using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FinancialReports.DTOs
{
    public class TrialBalanceDto
    {
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public decimal OpeningDebit { get; set; }
        public decimal OpeningCredit { get; set; }
        public decimal PeriodDebit { get; set; }
        public decimal PeriodCredit { get; set; }
        public decimal ClosingDebit => CalculateClosing().debit;
        public decimal ClosingCredit => CalculateClosing().credit;

        private (decimal debit, decimal credit) CalculateClosing()
        {
            var net = (OpeningDebit - OpeningCredit) + (PeriodDebit - PeriodCredit);
            return net > 0 ? (net, 0) : (0, Math.Abs(net));
        }
    }
}


