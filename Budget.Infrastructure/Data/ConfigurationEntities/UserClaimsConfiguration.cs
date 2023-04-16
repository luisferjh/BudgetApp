using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Budget.Infrastructure.Data.ConfigurationEntities
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(x => x.IdUser)
               .HasColumnName("id_user")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.ClaimType)
                .HasColumnName("claim_type")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            builder.Property(x => x.ClaimValue)
              .HasColumnName("claim_value")
              .HasColumnType("nvarchar(20)")
              .IsRequired();
            
            builder.HasOne(s => s.User)
               .WithMany(g => g.UserClaims)
               .HasForeignKey(s => s.IdUser)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
