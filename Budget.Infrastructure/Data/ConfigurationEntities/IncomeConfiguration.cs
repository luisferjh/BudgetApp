using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id")
               .HasColumnType("int");

            builder.Property(x => x.IdUser)
               .HasColumnType("int")
               .HasColumnName("id_user");

            builder.Property(x => x.IdFinancialProduct)
               .HasColumnType("int")
               .HasColumnName("id_financial_product");

            builder.Property(x => x.IdIncomeCategory)
               .HasColumnType("int")
               .HasColumnName("id_income_category");

            builder.Property(x => x.IdOperation)
              .HasColumnType("int")
              .HasColumnName("id_operation");

            builder.Property(x => x.IdState)
                .HasColumnType("int")
                .HasColumnName("idState");

            builder.Property(x => x.Year)
                .HasColumnType("int")
                .HasColumnName("year");

            builder.Property(x => x.TransactionNumber)
               .HasColumnType("nvarchar(50)")
               .HasColumnName("transaction_number");

            builder.Property(x => x.Amount)
               .HasColumnType("decimal(18,2)")
               .HasColumnName("amount");

            builder.Property(x => x.Description)
              .HasColumnType("nvarchar(200)")
              .HasColumnName("description");

            builder.Property(x => x.CreatedDate)
             .HasColumnType("datetime")
             .HasColumnName("created_date")
             .IsRequired()
             .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UpdatedDate)
             .HasColumnType("datetime")
             .HasColumnName("updated_date")
             .IsRequired(false)
             .HasDefaultValue(null);

            builder.HasOne(x => x.IncomeCategory)
             .WithMany(x => x.Incomes)
             .HasForeignKey(x => x.IdIncomeCategory)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Operation)
                .WithMany(x => x.Incomes)
                .HasForeignKey(x => x.IdOperation)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.State)
                .WithMany(x => x.Incomes)
                .HasForeignKey(x => x.IdState)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
              .WithMany(x => x.Incomes)
              .HasForeignKey(x => x.IdUser)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FinancialProduct)
              .WithMany(x => x.Incomes)
              .HasForeignKey(x => x.IdFinancialProduct)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
