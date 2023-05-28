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
    public class PaymentDatePeriodConfiguration : IEntityTypeConfiguration<PaymentDatePeriod>
    {
        public void Configure(EntityTypeBuilder<PaymentDatePeriod> builder)
        {
            builder.ToTable("PaymentDatePeriods");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(x => x.IdPeriodicity)
               .HasColumnName("id_periodicity")
               .HasColumnType("int");

            builder.Property(x => x.InitDate)
               .HasColumnName("init_date")
               .HasColumnType("datetime");

            builder.Property(x => x.FinalDate)
               .HasColumnName("final_date")
               .HasColumnType("datetime");

            builder.Property(x => x.PaymentDate)
               .HasColumnName("payment_date")
               .HasColumnType("nvarchar(20)");

            builder.Property(x => x.UnitDate)
              .HasColumnName("unit_date")
              .HasColumnType("nvarchar(20)");

            builder.Property(x => x.Year)
              .HasColumnName("year")
              .HasColumnType("int");

            builder.Property(x => x.IdState)
               .HasColumnName("id_state")
               .HasColumnType("int");

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey("IdState")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Periodicity)
                .WithOne(x => x.PaymentDatePeriod)
                .HasForeignKey<PaymentDatePeriod>(x => x.IdPeriodicity)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
