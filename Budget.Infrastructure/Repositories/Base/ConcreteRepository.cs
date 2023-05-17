using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories.Base
{
    public class ConcreteRepository<T> : GenericRepository<T>, IConcreteRepository<T>  where T: class
    {
        private readonly BudgetDbContext _budgetDbContext;

        public ConcreteRepository(BudgetDbContext budgetDbContext)
            :base(budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }
    }
}
