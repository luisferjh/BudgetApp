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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
             .HasColumnType("int")
             .HasColumnName("id");

            builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(s => s.DNIType)
            .HasColumnType("nvarchar(20)")
             .HasColumnName("dni_type")
            .IsRequired();

            builder.Property(s => s.DNI)
            .HasColumnType("nvarchar(20)")
            .HasColumnName("dni")
            .IsRequired();

            builder.Property(s => s.Email)
            .HasColumnType("nvarchar(50)")
             .HasColumnName("email")
             .IsRequired();

            builder.Property(s => s.Password)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("password")
            .IsRequired();

            builder.Property(s => s.State)
            .HasColumnType("int")
            .HasColumnName("id_state")
            .IsRequired();

            builder.Property(s => s.CreatedDate)
            .HasColumnType("date")
            .HasColumnName("created_date")
            .IsRequired();

           
        }
    }
}
