using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudgetDbContext _dbContexnt;
        private readonly IUserRepository _userRepository;
        public UnitOfWork(BudgetDbContext budgetDbContext, IUserRepository userRepository)
        {
            _dbContexnt = budgetDbContext;  
            _userRepository = userRepository;            
        }

        public IUserRepository UserRepository { get => _userRepository; }

        public async Task SaveAsync()
        {
            await _dbContexnt.SaveChangesAsync();
        }
    }
}
