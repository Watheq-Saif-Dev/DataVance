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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);

            // إنشاء Index فريد لمنع تكرار الصلاحية (Unique Constraint)
            builder.HasIndex(x => new { x.TargetId, x.PageId, x.ActionId }).IsUnique();

            builder.Property(x => x.ActionCode).IsRequired().HasMaxLength(50);

            // ربط العلاقات
            builder.HasOne(x => x.Page)
                   .WithMany()
                   .HasForeignKey(x => x.PageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Action)
                   .WithMany()
                   .HasForeignKey(x => x.ActionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
