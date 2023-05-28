using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class FixedIncomeRepository : IFixedIncomeRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public FixedIncomeRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<IEnumerable<FixedIncome>> GetAllByUserAsync(int idUser)
        {
            var fixedIncomes = await _budgetDbContext.FixedIncomes.Where(w => w.IdUser == idUser).ToListAsync();
            return fixedIncomes.AsEnumerable();
        }

        public async Task<FixedIncome> GetAsync(int id)
        {
            return await _budgetDbContext.FixedIncomes.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task InsertFixedIncomeAsync(FixedIncome fixedIncome)
        {
            await _budgetDbContext.FixedIncomes.AddAsync(fixedIncome);
        }
    }
}
