using DataVance.Domain.Finance.AccountingClosing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IFiscalYearRepository
    {
        Task<FiscalYear?> GetByIdAsync(Guid id);
        Task<FiscalYear?> GetActiveYearAsync();
        Task UpdateAsync(FiscalYear fiscalYear);
        Task AddAsync(FiscalYear fiscalYear);
        Task<bool> IsOverlappingAsync(DateTime startDate, DateTime endDate);
    }
}


