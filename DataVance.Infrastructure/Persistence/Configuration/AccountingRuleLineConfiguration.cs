namespace DataVance.Infrastructure.Persistence.Configuration
{
    using DataVance.Domain.Finance.Accounting.Entities;
    using DataVance.Domain.Finance.Rules.Entities;
    using DataVance.Domain.Finance.Rules.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    // 3. إعدادات جدول AccountingRuleLine
    public class AccountingRuleLineConfiguration : IEntityTypeConfiguration<AccountingRuleLine>
    {
        public void Configure(EntityTypeBuilder<AccountingRuleLine> builder)
        {
            builder.ToTable("AccountingRuleLines");
            builder.HasKey(x => x.Id);

            // 🔥 تخزين الـ Enums كنصوص لسهولة القراءة في الداتابيز
            builder.Property(x => x.EntrySide)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.AccountSourceType)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Purpose)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                 .IsRequired();
            builder.Property(x => x.AmountSourceType)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();


            builder.HasOne<Account>()
               .WithMany()
               .HasForeignKey(x => x.StaticAccountId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);
        }
    }
}

