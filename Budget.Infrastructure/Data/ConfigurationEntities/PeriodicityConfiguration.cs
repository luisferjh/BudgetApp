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
    public class PeriodicityConfiguration : IEntityTypeConfiguration<Periodicity>
    {
        public void Configure(EntityTypeBuilder<Periodicity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id")
               .HasColumnType("int");

            builder.Property(x => x.Description)
              .HasColumnName("description")
              .HasColumnType("nvarchar(20)")
              .IsRequired();

            builder.Property(x => x.AmountPay)
              .HasColumnName("amount_pay")
              .HasColumnType("tinyint")
              .IsRequired();

            builder.Property(x => x.AmountPayYear)
             .HasColumnName("amount_pay_year")
             .HasColumnType("tinyint")
             .IsRequired();

            builder.Property(x => x.MonthUnit)
             .HasColumnName("month_unit")
             .HasColumnType("tinyint")
             .IsRequired();

            builder.Property(x => x.DayUnit)
             .HasColumnName("day_unit")
             .HasColumnType("tinyint")
             .IsRequired();

            builder.Property(x => x.IsFixedInterval)
               .HasColumnName("is_fixed_intervar")
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(x => x.IdState)
               .HasColumnName("id_state")
               .HasColumnType("int")
               .IsRequired();

            builder.HasOne(x => x.State)
            .WithMany()
            .HasForeignKey("IdState")
            .OnDelete(DeleteBehavior.NoAction);

            // this can be usefull for properties who relation in each other
            // don't have navigation properties
            // even if we don't hace and id property Foreign key

            //builder.HasMany(typeof(State))
            //  .WithOne()
            //  .HasForeignKey("id_state")
            //  .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(typeof(State))
            //   .WithMany()
            //   .HasForeignKey("IdState")
            //   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
