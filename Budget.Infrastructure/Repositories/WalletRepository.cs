using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public WalletRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<IEnumerable<Wallet>> GetFinanceProductsUserAsync(int idUser)
        {
            try
            {
                List<Wallet> result = await _budgetDbContext.Wallets.Where(w => w.IdUser == idUser).ToListAsync();
                return result.AsEnumerable();
            }
            catch (Exception ex)
            {
                await _budgetDbContext.LogErrors.AddAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetFinanceProductUser",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Key = idUser.ToString()
                });
                await _budgetDbContext.SaveChangesAsync();
                return null;
            }
           
        }

        public async Task<IEnumerable<Wallet>> GetFinanceProductsUserAsync(string DocUser)
        {
            try
            {
                List<Wallet> result = await _budgetDbContext.Wallets.Where(w => w.DNI == DocUser).ToListAsync();
                return result.AsEnumerable();
            }
            catch (Exception ex)
            {
                await _budgetDbContext.LogErrors.AddAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetFinanceProductUser",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Key = DocUser
                });
                await _budgetDbContext.SaveChangesAsync();
                return null;
            }
           
        }

        public async Task<Wallet> GetFinanceProductUserAsync(int id)
        {
            return await _budgetDbContext.Wallets.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task InsertAsync(Wallet wallet)
        {
            await _budgetDbContext.Wallets.AddAsync(wallet);
        }

        public void Update(Wallet wallet)
        {
            _budgetDbContext.Wallets.Update(wallet);
        }

       
    }
}
