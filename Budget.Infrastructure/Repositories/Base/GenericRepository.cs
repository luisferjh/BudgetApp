using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories.Base
{

    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly BudgetDbContext _dbContext;  
        public GenericRepository(BudgetDbContext dbContext)          
        {
            _dbContext = dbContext;
        }
       
        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);   
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task AddAsync(T model)
        {
            await _dbContext.Set<T>().AddAsync(model);
        }

        public void Add(T model)
        {
            _dbContext.Set<T>().Add(model);
        }

        public void Update(T model)
        {
            _dbContext.Set<T>().Update(model);
        }

        public void Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
