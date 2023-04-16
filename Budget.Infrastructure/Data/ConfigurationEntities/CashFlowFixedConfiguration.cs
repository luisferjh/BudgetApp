using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class CashFlowFixedConfiguration : IEntityTypeConfiguration<CashFlowFixed>
    {
        public void Configure(EntityTypeBuilder<CashFlowFixed> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id")
               .HasColumnType("int");

            builder.Property(x => x.IdOperation)
               .HasColumnName("id_operation")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.IdCategory)
              .HasColumnName("id_category")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.IdUser)
              .HasColumnName("id_user")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.Idperiodicity)
              .HasColumnName("id_periodicity")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.Year)
              .HasColumnName("year")
              .HasColumnType("int")
              .IsRequired();

            builder.Property(x => x.Amount)
              .HasColumnName("amount")
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.CreatedDate)
              .HasColumnName("created_date")
              .HasColumnType("datetime")
              .IsRequired();

            builder.Property(x => x.IdState)
              .HasColumnName("id_state")
              .HasColumnType("int")
              .IsRequired();

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey("IdState")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Periodicity)
                .WithMany(x => x.CashFlowFixeds)
                .HasForeignKey(x => x.Idperiodicity)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.CashFlowFixeds)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Operation)
                .WithMany()
                .HasForeignKey("IdOperation")
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(typeof(Operation))
            //    .WithMany()
            //    .HasForeignKey("IdOperation")
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.IncomeCategory)
                .WithMany(x => x.CashFlowFixeds)
                .HasForeignKey(x => x.IdCategory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SpentDetail)
                .WithMany(x => x.CashFlowFixeds)
                .HasForeignKey(x => x.IdCategory)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.CategoryID)
            //    .WithMany()
            //    .HasForeignKey(x => x.IdCategory)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
