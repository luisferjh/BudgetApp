using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IFixedIncomeRepository
    {
        Task<IEnumerable<FixedIncome>> GetAllByUserAsync(int idUser);
        Task<FixedIncome> GetAsync(int id);
        Task InsertFixedIncomeAsync(FixedIncome fixedIncome);
    }
}
