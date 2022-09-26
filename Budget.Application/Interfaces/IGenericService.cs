using Budget.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IGenericService<T> where T: class 
    {                
        Task<T> GetAsync(int id);     
        Task<ResponseServiceDTO> InsertAsync(T model);        
        Task<ResponseServiceDTO> UpdateAsync(T model);       
        Task<ResponseServiceDTO> DeleteAsync(int id);
        
    }
}
