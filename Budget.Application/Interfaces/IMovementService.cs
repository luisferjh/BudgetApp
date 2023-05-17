using Budget.Domain.DTOS.Models;
using Budget.Infrastructure.DTOS.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IMovementService
    {
        Task<ResponseServiceDTO> InsertAsync(CreateMovementDTO createMovementDTO);
    }
}
