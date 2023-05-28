using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class FixedIncomeConfiguration : IEntityTypeConfiguration<FixedIncome>
    {
        public void Configure(EntityTypeBuilder<FixedIncome> builder)
        {
            builder.ToTable("FixedIncomes");

            builder.HasKey(s => s.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id")
               .HasColumnType("int");

            builder.Property(x => x.IdOperation)
               .HasColumnName("id_operation")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.IdIncomeCategory)
              .HasColumnName("id_income_category")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.IdUser)
              .HasColumnName("id_user")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.IdPaymentDatePeriod)
              .HasColumnName("id_payment_date_period")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.IdWallet)
             .HasColumnName("id_wallet")
             .HasColumnType("int")
             .IsRequired()
             .HasDefaultValue(null);

            builder.Property(x => x.Amount)
              .HasColumnName("amount")
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.CreatedDate)
              .HasColumnName("created_date")
              .HasColumnType("datetime")
              .IsRequired()
              .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UpdatedDate)
             .HasColumnName("updated_date")
             .HasColumnType("datetime")
             .IsRequired(false)
             .HasDefaultValue(null);

            builder.Property(x => x.IdState)
              .HasColumnName("id_state")
              .HasColumnType("int")
              .IsRequired();

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey("IdState")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PaymentDatePeriod)
                .WithOne(x => x.FixedIncome)
                .HasForeignKey<FixedIncome>(x => x.IdPaymentDatePeriod)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.FixedIncomes)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Operation)
                .WithMany()
                .HasForeignKey("IdOperation")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.IncomeCategory)
                .WithMany(x => x.FixedIncomes)
                .HasForeignKey(x => x.IdIncomeCategory)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(typeof(Operation))
            //    .WithMany()
            //    .HasForeignKey("IdOperation")
            //    .OnDelete(DeleteBehavior.NoAction);


            //builder.HasOne(x => x.SpentDetail)
            //    .WithMany(x => x.CashFlowFixeds)
            //    .HasForeignKey(x => x.IdCategory)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.CategoryID)
            //    .WithMany()
            //    .HasForeignKey(x => x.IdCategory)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
