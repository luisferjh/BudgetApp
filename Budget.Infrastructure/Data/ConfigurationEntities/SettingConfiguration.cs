using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");

            builder.HasKey(w => w.Id);

            builder.Property(x => x.Id)
              .HasColumnType("int")
              .HasColumnName("id");

            builder.Property(x => x.Serie)
              .HasColumnType("nvarchar(10)")
              .HasColumnName("serie");

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar(150)")
                .HasColumnName("description");

            builder.Property(x => x.Value)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("value");

            builder.Property(x => x.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
        }
    }
}
