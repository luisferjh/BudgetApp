using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IIncomeCategoryRepository : IGenericRepository<IncomeCategory>
    {
        Task<IncomeCategory> GetAsync(string id);
        Task<IncomeCategory> GetByCodeAsync(string code);
        Task<bool> IncomeCategoryExistsAsync(int id);
        bool IncomeCategoryExists(int id);
    }
}
