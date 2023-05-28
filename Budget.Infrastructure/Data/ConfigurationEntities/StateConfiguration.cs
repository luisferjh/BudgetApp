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
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");
            builder.HasKey(e => e.IdState);

            builder.Property(s => s.IdState)
                .HasColumnType("int")
                .HasColumnName("id_state");

            builder.Property(s => s.Code)
                .HasColumnType("nvarchar(10)")
                .IsRequired();

            builder.Property(s => s.Description)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
        }
    }
}
