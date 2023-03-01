using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Data
{
    public class BudgetDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LogError> LogErrors { private get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            :base(options)
        {

        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.Id);
                 
                entity.Property(e => e.Id)
                .HasColumnName("id");

                entity.Property(s => s.Name)
                .HasColumnName("name")
                .HasColumnName("nvarchar(50)");               

                entity.Property(s => s.DNIType)
                .HasColumnType("nvarchar(20)")
                 .HasColumnName("dni_type")
                .IsRequired();

                entity.Property(s => s.DNI)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("dni")
                .IsRequired();

                entity.Property(s => s.Email)
                .HasColumnType("nvarchar(50)")
                 .HasColumnName("email")
                 .IsRequired();

                entity.Property(s => s.Password)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("password")
                .IsRequired();

                entity.Property(s => s.State)
                .HasColumnType("int")
                .HasColumnName("state")
                .IsRequired();

                entity.Property(s => s.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("created_date")
                .IsRequired();

            });

            modelBuilder.Entity<State>(entity => {
                entity.HasKey(e => e.IdState);

                entity.Property(s => s.Code)
                    .HasColumnType("nvarchar(10)")
                    .IsRequired();

                entity.Property(s => s.Description)
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();
            });

            modelBuilder.Entity<LogError>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

           
        }


    }
}
