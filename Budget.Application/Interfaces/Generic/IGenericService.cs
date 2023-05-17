using Budget.Domain.DTOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces.Generic
{
    public interface IGenericService<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);           
        int Delete(int id);


    }
}
