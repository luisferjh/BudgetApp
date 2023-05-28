using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movements");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(x => x.IdOperation)
                .HasColumnName("id_operation")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IdAccountingEntry)
               .HasColumnName("id_accounting_entry")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.IdPreviousTransaction)
              .HasColumnName("id_previous_transaction")
              .HasColumnType("int");              

            builder.Property(x => x.TransactionNumber)
                .HasColumnName("transaction_number")
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.AccountNumber)
                 .HasColumnName("account_number")
                 .HasColumnType("nvarchar(20)")
                 .IsRequired();

            builder.Property(x => x.DNI)
               .HasColumnName("dni")
               .HasColumnType("nvarchar(20)")
               .IsRequired();

            builder.Property(x => x.Amount)
               .HasColumnName("amount")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            builder.Property(x => x.CreatedDate)
               .HasColumnName("created_date")
               .HasColumnType("datetime")
               .IsRequired()
               .HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.Operation)
                .WithMany(x => x.Movements)
                .HasForeignKey(x => x.IdOperation)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AccountingEntry)
                .WithMany(x => x.Movements)
                .HasForeignKey(x => x.IdAccountingEntry)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.MovementPrevious)
               .WithOne()
               .HasForeignKey<Movement>(x => x.IdPreviousTransaction)
               .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
