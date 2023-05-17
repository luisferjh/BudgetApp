using Budget.Application.Interfaces;
using Budget.Infrastructure.DTOS.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class OperationService : IOperationService
    {
        public Task<IEnumerable<OperationDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}
