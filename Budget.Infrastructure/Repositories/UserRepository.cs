using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Budget.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {        
        public UserRepository(BudgetDbContext dbContext)
            : base(dbContext) { }

      

        public async Task<User> Get(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == email);
        }

        public void Deactivate(User user)
        {
            user.State = 0;           
        }
       
    }

}
