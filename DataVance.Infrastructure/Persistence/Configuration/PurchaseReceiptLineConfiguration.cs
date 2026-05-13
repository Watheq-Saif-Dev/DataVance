using DataVance.Domain.Warehousing.Movements.PurchaseSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence.Configuration
{
    public class PurchaseReceiptLineConfiguration : IEntityTypeConfiguration<PurchaseReceiptLine>
    {
        public virtual void Configure(EntityTypeBuilder<PurchaseReceiptLine> builder)
        {
            builder.HasKey(x => x.Id);

            // ضبط الدقة العشرية (18 رقم، 4 منها للكسور)
            builder.Property(x => x.Quantity).HasPrecision(18, 4);
            builder.Property(x => x.UnitCost).HasPrecision(18, 4);
            builder.Property(x => x.ConversionFactor).HasPrecision(18, 4);

            // ربط العلاقة مع الرأس (Header)
            builder.HasOne<PurchaseReceipt>()
                   .WithMany(x => x.Lines)
                   .HasForeignKey(x => x.PurchaseReceiptId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.BatchNumber).HasMaxLength(50);
        }
    }
}
