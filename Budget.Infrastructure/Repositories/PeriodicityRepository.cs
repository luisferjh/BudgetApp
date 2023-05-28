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
    public class PeriodicityRepository : IPeriodicitiesRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public PeriodicityRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<IEnumerable<Periodicity>> GetAllAsync()
        {
            var periodicities =  await _budgetDbContext.Periodicities.ToListAsync();
            return periodicities.AsEnumerable();
        }

        public async Task<Periodicity> GetAsync(int id)
        {
            return await _budgetDbContext.Periodicities.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
