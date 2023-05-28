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
    public class SpentCategoriesConfiguration: IEntityTypeConfiguration<SpentCategory>
    {
        public void Configure(EntityTypeBuilder<SpentCategory> builder)
        {
            builder.ToTable("SpentCategories");

            builder.HasKey(w => w.Id);

            builder.Property(x => x.Id)
              .HasColumnType("int")
              .HasColumnName("id");

            builder.Property(x => x.Code)
               .HasColumnType("nvarchar(10)")
               .HasColumnName("code");

            builder.Property(x => x.Description)
              .HasColumnType("nvarchar(200)")
              .HasColumnName("description");

            builder.Property(x => x.IdState)
              .HasColumnType("int")
              .HasColumnName("id_state");

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey("IdState")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
