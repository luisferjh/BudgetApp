using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.FixedIncomes;
using Budget.Infrastructure.DTOS.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IFixedIncomeService
    {
        Task<ResponseServiceDTO> AddFixedIncomeAsync(CreateFixedIncomeDTO fixedIncomeDto);
        Task<IEnumerable<FixedIncomeDTO>> GetAllFixedIncomesAsync(int idUser);
        Task<FixedIncomeDTO> GetAsync(int id);
        Task<ResponseServiceDTO> RunFixedIncomeAsync();
    }
}
