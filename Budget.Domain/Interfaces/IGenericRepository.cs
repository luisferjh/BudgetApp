using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T model);
        void Update(T model);
        void Delete(T model);


        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T model);
    }
}
