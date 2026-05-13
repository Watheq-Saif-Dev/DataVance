namespace DataVance.Infrastructure.Persistence.Configuration
{
    using DataVance.Domain.Finance.Rules.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    // 2. إعدادات جدول AccountingRule
    public class AccountingRuleConfiguration : IEntityTypeConfiguration<AccountingRule>
    {
        public void Configure(EntityTypeBuilder<AccountingRule> builder)
        {
            builder.ToTable("AccountingRules");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.JournalEntryType)
                .HasMaxLength(20)
                .IsRequired();

            // إعداد علاقة رأس القاعدة مع العملية
            builder.HasOne<AccountingOperation>()
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict); // منع حذف العملية إذا كان لها قواعد مرتبطة

            builder.Property(x => x.Description)
               .HasMaxLength(500);

            // إعداد علاقة الرأس مع التفاصيل (الأسطر)
            var navigation = builder.Metadata.FindNavigation(nameof(AccountingRule.Lines));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field); // لكي يتعامل EF مع _lines مباشرة

            builder.HasMany(x => x.Lines)
                   .WithOne()
                   .HasForeignKey(x => x.RuleId)
                   .OnDelete(DeleteBehavior.Cascade); // إذا حُذفت القاعدة، تُحذف أسطرها
                                                      // أضف هذا السطر في نهاية دالة Configure
                                                      // يساعد هذا الفهرس في تسريع عملية الـ Mapping عند توليد القيود
            builder.HasIndex(x => new { x.OperationId, x.BranchId }).HasDatabaseName("IX_Rule_Operation_Branch");
        }
    }
}
