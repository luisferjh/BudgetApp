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
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Banks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Code)
               .HasColumnName("code")
               .HasColumnType("nvarchar(10)")
               .IsRequired();

            builder.Property(x => x.IsNeoBank)
             .HasColumnName("is_neo_bank")
             .HasColumnType("bit")
             .IsRequired();

            builder.Property(x => x.IdState)
                .HasColumnName("id_state")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.State)
                .WithMany(x => x.Banks)
                .HasForeignKey(x => x.IdState)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
