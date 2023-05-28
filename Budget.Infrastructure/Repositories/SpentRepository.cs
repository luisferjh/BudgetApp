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
    public class SpentRepository : ISpentRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public SpentRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public void Add(Spent model)
        {
            _budgetDbContext.Spents.Add(model);
        }

        public async Task AddAsync(Spent model)
        {
            await _budgetDbContext.Spents.AddAsync(model);
        }

        public async Task<IEnumerable<Spent>> GetSpentsByUser(int idUser, int year, int idSpentDetail)
        {
            bool flagYear = false;
            bool flagSpentItem = false;

            if (year <= 0)
                flagYear = true;

            if (idSpentDetail <= 0)
                flagSpentItem = true;

            Expression<Func<Spent, bool>> predicate = (f) =>
                f.IdUser == idUser &&
                (f.Year == year || flagYear) &&
                (f.IdSpentDetail == idSpentDetail || flagSpentItem);


            //var incomes = _context.Incomes.Where(w => w.IdUser == idUser).AsEnumerable();
            var spents = _budgetDbContext.Spents.Where(predicate).AsEnumerable();
            return spents;
        }
    }
}
