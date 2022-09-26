using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BudgetDbContext _dbContext;
        public UserRepository(BudgetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<User> Get(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<User> Get(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == username);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public Task Insert(User model)
        {
            throw new NotImplementedException();
        }

        public Task Update(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
