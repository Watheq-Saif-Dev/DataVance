using DataVance.Domain.Finance.Accounting.Entities;
using DataVance.Domain.Finance.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence.Configuration
{
    public class AccountMappingConfiguration : IEntityTypeConfiguration<AccountMapping>
    {
        public void Configure(EntityTypeBuilder<AccountMapping> builder)
        {
            builder.ToTable("AccountMappings", "Accounting"); // وضعها في سكيم المحاسبة
            builder.HasKey(x => x.Id);

            // تحويل الـ Enums إلى نصوص لسهولة تتبع قاعدة البيانات
            builder.Property(x => x.AccountSourceType).HasConversion<string>().HasMaxLength(30);
            builder.Property(x => x.Purpose).HasConversion<string>().HasMaxLength(50);

            // ⚠️ أهم نقطة: الفهرس الفريد (Unique Index)
            // يمنع تكرار ربط نفس الكيان لنفس الغرض في نفس الفرع
            builder.HasIndex(x => new { x.ReferenceId, x.AccountSourceType, x.Purpose, x.BranchId })
                   .IsUnique()
                   .HasDatabaseName("IX_Unique_Mapping_Per_Branch");

            // ربط الحساب المالي (AccountId) مع شجرة الحسابات
            builder.HasOne<Account>()
                   .WithMany()
                   .HasForeignKey(x => x.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

