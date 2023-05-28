using Budget.Domain.DTOS.Models;
using Budget.Infrastructure.DTOS.Incomes;
using Budget.Infrastructure.DTOS.Spents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface ISpentService
    {
        Task<ResponseServiceDTO> AddSpentAsync(CreateSpentDTO createSpentDTO);
        Task<IEnumerable<SpentDTO>> GetSpentsByUser(int idUser, int year, int idSpentCategory);
    }
}
