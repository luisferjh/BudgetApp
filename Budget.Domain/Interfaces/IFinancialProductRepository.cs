using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IFinancialProductRepository:IGenericRepository<FinancialProduct>
    {
        Task<FinancialProduct> GetAsync(string id);
        Task<bool> FinancialProductExistsAsync(int id);
        bool FinancialProductExists(int id);
    }
}
