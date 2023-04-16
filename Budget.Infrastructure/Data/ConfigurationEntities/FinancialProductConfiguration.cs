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
    public class FinancialProductConfiguration : IEntityTypeConfiguration<FinancialProduct>
    {
        public void Configure(EntityTypeBuilder<FinancialProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            builder.Property(x => x.IdAccountingEntry)
                .HasColumnType("int")
                .HasColumnName("id_accounting_entry")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.IdState)
                 .HasColumnType("int")
                 .HasColumnName("id_state")
                 .IsRequired();

            builder.HasOne(x => x.AccountingEntry)
                .WithMany(x => x.FinancialProducts)
                .HasForeignKey(x => x.IdAccountingEntry);

            builder.HasOne(x => x.State)
                .WithMany(x => x.FinancialProducts)
                .HasForeignKey(x => x.IdState)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
