using Budget.Domain.DTOS.Models;
using Budget.Infrastructure.DTOS.Incomes;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IIncomeService
    {
        Task<ResponseServiceDTO> AddIncomeAsync(CreateIncomeDTO createIncomeDTO);
        Task<IEnumerable<IncomeDTO>> GetIncomesByUser(int idUser, int year, int idIncomeCategory);
    }
}
