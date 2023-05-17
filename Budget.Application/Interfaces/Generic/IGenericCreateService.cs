using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces.Generic
{
    public interface IGenericCreateService<T> where T : class
    {
        Task<int> AddAsync(T model);
    }
}
