using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Income>> GetIncomesByUser(int idUser, int year, int idIncomeCategory)
        {            
            bool flagYear = false;
            bool flagIncomeCategory = false ;

            if (year <= 0)            
                flagYear = true;

            if (idIncomeCategory <= 0)
                flagIncomeCategory = true;

            Expression<Func<Income, bool>> predicate = (f) =>
                f.IdUser == idUser &&
                (f.Year == year || flagYear) && 
                (f.IdIncomeCategory == idIncomeCategory || flagIncomeCategory);
                        
            var incomes = _context.Incomes.Where(predicate).AsEnumerable();
            return incomes;
        }
    }
}
