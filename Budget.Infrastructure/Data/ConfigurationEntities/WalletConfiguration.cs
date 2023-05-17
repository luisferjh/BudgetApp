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
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(x => x.IdUser)
               .HasColumnName("id_user")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.IdFinancialProd)
               .HasColumnName("id_financial_prod")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.IdBank)
             .HasColumnName("id_bank")
             .HasColumnType("int")
             .IsRequired();

            builder.Property(x => x.DNI)
              .HasColumnName("DNI")
              .HasColumnType("nvarchar(20)")
              .IsRequired();

            builder.Property(x => x.AccountNumber)
                .HasColumnName("account_number")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(x => x.Balance)
                .HasColumnName("balance")
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
                .IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Wallets)
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FinancialProduct)
               .WithMany(x => x.FinancialProductUsers)
               .HasForeignKey(x => x.IdFinancialProd)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Bank)
             .WithMany(x => x.Wallets)
             .HasForeignKey(x => x.IdBank)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
