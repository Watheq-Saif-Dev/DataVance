using DataVance.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Persistence.Configuration
{

    public class SystemSettingConfiguration : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            builder.ToTable("SystemSettings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SettingKey)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.SettingValue)
                .IsRequired();

            builder.Property(x => x.ValueType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LookupType)
                .HasMaxLength(100);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.IsSystem)
                .IsRequired();

            // منع تكرار الإعداد
            builder.HasIndex(x => new { x.Category, x.SettingKey })
                .IsUnique();
        }
    }
}
