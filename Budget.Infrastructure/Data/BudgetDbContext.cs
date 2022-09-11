using Budget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Data
{
    public class BudgetDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            :base(options)
        {

        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.Id);
            });
        }


    }
}
