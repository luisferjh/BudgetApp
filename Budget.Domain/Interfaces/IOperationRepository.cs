using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IOperationRepository : IGenericRepository<Operation>
    {
        Task<Operation> GetAsync(string code);
    }
}
