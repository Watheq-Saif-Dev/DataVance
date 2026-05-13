using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence.Configuration
{
    using DataVance.Domain.Finance.Rules.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    // 1. إعدادات جدول AccountingOperation
    public class AccountingOperationConfiguration : IEntityTypeConfiguration<AccountingOperation>
    {
        public void Configure(EntityTypeBuilder<AccountingOperation> builder)
        {
            builder.ToTable("AccountingOperations"); // وضعها في Schema مخصص
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Code).IsUnique(); // كود العملية يجب أن يكون فريداً

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();        }
    }
}
