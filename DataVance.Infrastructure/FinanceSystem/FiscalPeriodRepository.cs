using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.AccountingClosing.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class FiscalPeriodRepository : IFiscalPeriodRepository
    {
        private readonly IApplicationDbContext _context;

        public FiscalPeriodRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FiscalPeriod?> GetByIdAsync(Guid id)
        {
            return await _context.FiscalPeriods.FindAsync(id);
        }

        public void Update(FiscalPeriod period)
        {
            _context.FiscalPeriods.Update(period);
        }
        public async Task<FiscalPeriod?> GetPeriodByDateAsync(DateTime date)
        {
            return await _context.FiscalPeriods
                .FirstOrDefaultAsync(p => date.Date >= p.StartDate.Date && date.Date <= p.EndDate.Date);
        }
        // ملاحظة للمهندسين: يفضل دائماً جلب الفترة مع حالتها (IsClosed) 
        // للتحقق منها قبل أي عملية مالية.
    }
}
