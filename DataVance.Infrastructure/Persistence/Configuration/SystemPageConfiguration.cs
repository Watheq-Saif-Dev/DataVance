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
    public class SystemPageConfiguration : IEntityTypeConfiguration<SystemPage>
    {
        public void Configure(EntityTypeBuilder<SystemPage> builder)
        {
            builder.HasKey(x => x.Id);

            // إجبار EF على استخدام الحقل الخاص للمجموعة
            builder.Metadata.FindNavigation(nameof(SystemPage.AvailableActions))
                ?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ModuleName).IsRequired().HasMaxLength(100);

            // علاقة One-to-Many مع PageAction
            builder.HasMany(x => x.AvailableActions)
                   .WithOne(x => x.Page)
                   .HasForeignKey(x => x.PageId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
