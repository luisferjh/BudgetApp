using Budget.Application.Interfaces.Generic;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class GenericService<T> where T : class, IGenericService<T>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //return await _unitOfWork.GenericRepository<T>().GetAllAsync();
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int id)
        {
            //return await _unitOfWork.GenericRepository<T>().GetAsync(id);
            throw new NotImplementedException();
        }

        public async Task AddAsync(T model)
        {
            //await _unitOfWork.GenericRepository<T>().AddAsync(model);
            throw new NotImplementedException();
        }

        public void Delete(T model)
        {
            //_unitOfWork.GenericRepository<T>().Delete(model);
            throw new NotImplementedException();
        }

        public void Update(T model)
        {
            //_unitOfWork.GenericRepository<T>().Update(model);
            throw new NotImplementedException();
        }
    }
}
