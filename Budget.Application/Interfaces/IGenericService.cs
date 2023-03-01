using Budget.Domain.DTOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IGenericService<T> 
        where T: class        
    {                
        Task<T> GetAsync(int id);     
        T GetById(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();          
        
    }
}
