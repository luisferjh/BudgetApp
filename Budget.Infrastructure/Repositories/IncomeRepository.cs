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
    public class IncomeRepository:IIncomeRepository
    {
        private readonly BudgetDbContext _context;

        public IncomeRepository(BudgetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Income model)
        {
            await _context.Incomes.AddAsync(model);
        }

        public void Add(Income model)
        {
            _context.Incomes.Add(model);
        }

    }
}
