using Budget.Domain.Entities;
using Budget.Infrastructure.Data.ConfigurationEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Budget.Infrastructure.Data
{
    public class BudgetDbContext : DbContext
    {          
        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<FinancialProduct> FinancialProducts { get; set; }      
        public DbSet<AccountingEntry> AccountingEntries { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LogError> LogErrors { get; set; }         
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<SpentCategory> SpentCategories { get; set; }
        public DbSet<SpentDetail> SpentDetail { get; set; }
        public DbSet<Spent> Spents { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Periodicity> Periodicities { get; set; }
        public DbSet<FixedIncome> FixedIncomes { get; set; }        
        public DbSet<PaymentDatePeriod> PaymentDatePeriods { get; set; }
        public DbSet<Setting> Settings { get; set; }


        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            :base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());                                  
            modelBuilder.ApplyConfiguration(new LogConfiguration());                                                          
            modelBuilder.ApplyConfiguration(new BankConfiguration());                                              
            modelBuilder.ApplyConfiguration(new AccountingEntriesConfiguration());                                              
            modelBuilder.ApplyConfiguration(new FinancialProductConfiguration());                                              
            modelBuilder.ApplyConfiguration(new WalletConfiguration());                                              
            modelBuilder.ApplyConfiguration(new OperationConfiguration());                                              
            modelBuilder.ApplyConfiguration(new MovementConfiguration());                                              
            modelBuilder.ApplyConfiguration(new UserClaimsConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new IncomeCategoriesConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new SpentCategoriesConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new SpentConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new SpentDetailConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new IncomeConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new PeriodicityConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new FixedIncomeConfiguration());                                                         
            modelBuilder.ApplyConfiguration(new PaymentDatePeriodConfiguration());                                                                                                              
            modelBuilder.ApplyConfiguration(new SettingConfiguration());

            //base.OnModelCreating(modelBuilder);
           
        }


    }
}
