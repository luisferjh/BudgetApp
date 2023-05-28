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
    public class SpentDetailConfiguration : IEntityTypeConfiguration<SpentDetail>
    {
        public void Configure(EntityTypeBuilder<SpentDetail> builder)
        {
            builder.ToTable("SpentDetail");
            builder.HasKey(w => w.Id);

            builder.Property(x => x.Id)
              .HasColumnType("int")
              .HasColumnName("id");

            builder.Property(x => x.IdSpentCategory)
               .HasColumnType("int")
               .HasColumnName("id_spent_category");

            builder.Property(x => x.Description)
              .HasColumnType("nvarchar(200)")
              .HasColumnName("description");

            builder.Property(x => x.IdState)
              .HasColumnType("int")
              .HasColumnName("id_state");

            builder.HasOne(x => x.SpentCategory)
                .WithMany(x => x.SpentDetails)
                .HasForeignKey(x => x.IdSpentCategory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.State)
                .WithMany(x => x.SpentDetails)
                .HasForeignKey(x => x.IdState)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
