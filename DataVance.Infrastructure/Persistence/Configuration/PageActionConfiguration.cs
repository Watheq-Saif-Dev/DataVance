using DataVance.Domain.Entities.SecuritySystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence.Configuration
{
    public class PageActionConfiguration : IEntityTypeConfiguration<PageAction>
    {
        public void Configure(EntityTypeBuilder<PageAction> builder)
        {
            builder.HasKey(x => x.Id);

            // منع إضافة نفس العملية لنفس الصفحة مرتين
            builder.HasIndex(x => new { x.PageId, x.ActionId }).IsUnique();

            builder.HasOne(x => x.Action)
                   .WithMany()
                   .HasForeignKey(x => x.ActionId);
        }
    }
}
