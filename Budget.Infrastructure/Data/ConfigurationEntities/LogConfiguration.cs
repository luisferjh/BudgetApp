using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class LogConfiguration : IEntityTypeConfiguration<LogError>
    {
        public void Configure(EntityTypeBuilder<LogError> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
               .HasColumnType("int")
               .HasColumnName("id");
        }
    }
}
