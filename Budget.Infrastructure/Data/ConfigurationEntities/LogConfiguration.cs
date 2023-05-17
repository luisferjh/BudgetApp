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

            builder.Property(x => x.Layer)
              .HasColumnType("nvarchar(20)")
              .HasColumnName("layer")
              .IsRequired();

            builder.Property(x => x.StackTrace)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("stack_trace")
                  .IsRequired(false);

            builder.Property(x => x.InnerException)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("inner_exception")
                  .IsRequired(false);

            builder.Property(x => x.Exception)
               .HasColumnType("nvarchar(max)")
               .HasColumnName("exception")
                 .IsRequired(false);

            builder.Property(x => x.Data)
              .HasColumnType("nvarchar(max)")
              .HasColumnName("data")
              .IsRequired(false);

            builder.Property(x => x.Method)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("method")
                  .IsRequired() ;

            builder.Property(x => x.DateLog)
                .HasColumnType("datetime")
                .HasColumnName("data_log")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Key)
                .HasColumnType("nvarchar(30)")
                .HasColumnName("key")
                  .IsRequired(false);

            builder.Property(x => x.MessageError)
                .HasColumnType("nvarchar(200)")
                .HasColumnName("message_error")
                .IsRequired();
        }
    }
}
