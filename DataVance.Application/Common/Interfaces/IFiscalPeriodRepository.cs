using DataVance.Domain.Finance.AccountingClosing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IFiscalPeriodRepository
    {
        Task<FiscalPeriod?> GetPeriodByDateAsync(DateTime date);
        Task<FiscalPeriod?> GetByIdAsync(Guid id);
        void Update(FiscalPeriod period);
    }
}
