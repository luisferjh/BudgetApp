using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class AccountingEntriesConfiguration : IEntityTypeConfiguration<AccountingEntry>
    {
        public void Configure(EntityTypeBuilder<AccountingEntry> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            builder.Property(x => x.Code)
               .HasColumnType("nvarchar(10)")
               .HasColumnName("code")
               .IsRequired();

            builder.Property(x => x.Description)
              .HasColumnType("nvarchar(100)")
              .HasColumnName("description")
              .IsRequired();                          

        }
    }
}
