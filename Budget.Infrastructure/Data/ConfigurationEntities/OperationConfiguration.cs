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
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
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
                .HasColumnType("nvarchar(50)")
                .HasColumnName("description")
                .IsRequired();

        }
    }
}
