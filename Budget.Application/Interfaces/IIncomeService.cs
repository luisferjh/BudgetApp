using Budget.Domain.DTOS.Models;
using Budget.Infrastructure.DTOS.Incomes;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IIncomeService
    {
        Task<ResponseServiceDTO> AddIncomeAsync(CreateIncomeDTO createIncomeDTO);
    }
}
