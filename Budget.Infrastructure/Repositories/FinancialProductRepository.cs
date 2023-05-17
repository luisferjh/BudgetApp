using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using HashidsNet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class FinancialProductRepository : IFinancialProductRepository
    {
        private readonly BudgetDbContext _dbContext;
        private readonly IHashids _hashids;

        public FinancialProductRepository(
            BudgetDbContext dbContext,
            IHashids hashids)           
        {
            _hashids = hashids;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FinancialProduct>> GetAllAsync()
        {
            var financialProducts = await _dbContext.FinancialProducts.ToListAsync();
            return financialProducts.AsEnumerable();
        }

        public async Task<FinancialProduct> GetAsync(string id)
        {
            try
            {
                var arrayIdDecode = _hashids.Decode(id);
                if (arrayIdDecode.Length <= 0)
                    return null;

                var financialProduct = await _dbContext.FinancialProducts.FirstOrDefaultAsync(f => f.Id == arrayIdDecode[0]);
                return financialProduct;
            }
            catch (OverflowException ex)
            {
                await _dbContext.LogErrors.AddAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Infrastructure,
                    Key = id
                });
                await _dbContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                await _dbContext.LogErrors.AddAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Infrastructure,
                    Key = id
                });
                await _dbContext.SaveChangesAsync();
                return null;
            }
        }

        public async Task<FinancialProduct> GetAsync(int id)
        {
            return await _dbContext.FinancialProducts.FirstOrDefaultAsync(f => f.Id == id);
        }


        public void Add(FinancialProduct model)
        {
            _dbContext.FinancialProducts.Add(model);
        }

        public async Task AddAsync(FinancialProduct model)
        {
            await _dbContext.FinancialProducts.AddAsync(model);
        }

        public void Delete(int id)
        {
            var finProduct = _dbContext.FinancialProducts.FirstOrDefault(f => f.Id == id);
            _dbContext.FinancialProducts.Remove(finProduct);
        }

        public FinancialProduct Get(int id)
        {
            return _dbContext.FinancialProducts.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FinancialProduct> GetAll()
        {
            return _dbContext.FinancialProducts.ToList();
        }        

       
        public void Update(FinancialProduct model)
        {
            _dbContext.FinancialProducts.Add(model);
        }

        public async Task<bool> FinancialProductExistsAsync(int id)
        {
            return await _dbContext.FinancialProducts.AnyAsync(f => f.Id == id);
        }

        public bool FinancialProductExists(int id)
        {
            return _dbContext.FinancialProducts.Any(f => f.Id == id);
        }
    }
}
