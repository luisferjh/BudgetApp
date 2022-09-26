using Budget.Application.Interfaces;
using Budget.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseServiceDTO> InsertAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseServiceDTO> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseServiceDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
