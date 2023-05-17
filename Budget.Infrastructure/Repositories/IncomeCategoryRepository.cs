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
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        private readonly BudgetDbContext _budgetDbContext;
        private readonly IHashids _hashids;

        public IncomeCategoryRepository(
            BudgetDbContext budgetDbContext,
            IHashids hashids)
        {
            _budgetDbContext = budgetDbContext;
            _hashids = hashids;
        }

        public IncomeCategory Get(int id)
        {
            return _budgetDbContext.IncomeCategories.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<IncomeCategory> GetAll()
        {
            return _budgetDbContext.IncomeCategories.ToList();
        }

        public async Task<IEnumerable<IncomeCategory>> GetAllAsync()
        {
            var incomeCategories = await _budgetDbContext.IncomeCategories.ToListAsync();
            return incomeCategories.AsEnumerable();
        }

        public async Task<IncomeCategory> GetAsync(string id)
        {
            try
            {
                var arrayIdDecode = _hashids.Decode(id);
                if (arrayIdDecode.Length <= 0)
                    return null;

                var incomeCategory = await _budgetDbContext.IncomeCategories.FirstOrDefaultAsync(f => f.Id == arrayIdDecode[0]);
                return incomeCategory;
            }
            catch (OverflowException ex)
            {
                await _budgetDbContext.LogErrors.AddAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Infrastructure,
                    Key = id
                });
                await _budgetDbContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                await _budgetDbContext.LogErrors.AddAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Infrastructure,
                    Key = id
                });
                await _budgetDbContext.SaveChangesAsync();
                return null;
            }
        }

        public async Task<IncomeCategory> GetAsync(int id)
        {
            return await _budgetDbContext.IncomeCategories.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IncomeCategory> GetByCodeAsync(string code)
        {
            return await _budgetDbContext.IncomeCategories.FirstOrDefaultAsync(f => f.Code == code);
        }

        public void Add(IncomeCategory model)
        {
            _budgetDbContext.Add(model);
        }

        public async Task AddAsync(IncomeCategory model)
        {
           await _budgetDbContext.AddAsync(model);
        }         

        public bool IncomeCategoryExists(int id)
        {
            return _budgetDbContext.IncomeCategories.Any(f => f.Id == id);
        }

        public async Task<bool> IncomeCategoryExistsAsync(int id)
        {
            return await _budgetDbContext.IncomeCategories.AnyAsync(f => f.Id == id);
        }

        public void Update(IncomeCategory model)
        {
            _budgetDbContext.IncomeCategories.Add(model);
        }

        public void Delete(int id)
        {
            var incomeCategory = _budgetDbContext.IncomeCategories.FirstOrDefault(f => f.Id == id);
            _budgetDbContext.IncomeCategories.Remove(incomeCategory);
        }
      
    }
}
