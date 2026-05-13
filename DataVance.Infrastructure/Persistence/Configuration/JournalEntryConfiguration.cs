using DataVance.Domain.Finance.Journal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence.Configuration
{
    public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.ToTable("JournalEntries");

            builder.HasKey(x => x.Id);

            // ضبط رقم القيد كـ Index فريد لضمان عدم التكرار
            builder.HasIndex(x => x.EntryNumber).IsUnique();

            builder.Property(x => x.EntryNumber).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            // ضبط العملة
            builder.Property(x => x.CurrencyId).HasMaxLength(3).IsFixedLength();

            // ربط القيد العكسي (Self-Referencing Relationship)
            builder.HasOne<JournalEntry>()
                   .WithMany()
                   .HasForeignKey(x => x.ReversedEntryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ضبط الوصول للحقل الخاص _lines (Encapsulation)
            builder.Metadata.FindNavigation(nameof(JournalEntry.Lines))
                   ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
