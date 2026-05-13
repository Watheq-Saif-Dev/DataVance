using DataVance.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence
{
    public static class DbContextExtensions
    {
        public static void SetBranchFilter<TEntity>(ModelBuilder modelBuilder, ApplicationDbContext context)
            where TEntity : class, IBranchEntity
        {
            // بناء الفلتر: سيتم حقن CurrentBranchId في كل استعلام SQL آلياً
            modelBuilder.Entity<TEntity>().HasQueryFilter(x =>
                x.BranchId == context.CurrentBranchId);
        }
    }
}
