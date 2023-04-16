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
    public class TransactionFixedConfiguration : IEntityTypeConfiguration<TransactionFixed>
    {
        public void Configure(EntityTypeBuilder<TransactionFixed> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnType("int")
               .HasColumnName("id");

            builder.Property(x => x.IdOperation)
              .HasColumnType("int")
              .HasColumnName("id_operation");

            builder.Property(x => x.IdCashFlowFixed)
               .HasColumnType("int")
               .HasColumnName("id_cash_flow_fixed");

            builder.Property(x => x.Description)
               .HasColumnType("nvarchar(20)")
               .HasColumnName("description");

            builder.Property(x => x.Amount)
               .HasColumnType("decimal(18,2)")
               .HasColumnName("amount");

            builder.Property(x => x.Date)
               .HasColumnType("datetime")
               .HasColumnName("date");

            builder.Property(x => x.IdState)
                .HasColumnType("int")
                .HasColumnName("id_state");

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey("IdState")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CashFlowFixed)
               .WithMany(x => x.TransactionFixeds)
               .HasForeignKey(x => x.IdCashFlowFixed)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Income)
               .WithOne(x => x.TransactionFixed)
               .HasForeignKey<TransactionFixed>(x => x.IdOperation)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Spent)
             .WithOne(x => x.TransactionFixed)
             .HasForeignKey<TransactionFixed>(x => x.IdOperation)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
