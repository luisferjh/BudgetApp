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
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public UnitOfWork(BudgetDbContext budgetDbContext,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _dbContexnt = budgetDbContext;  
            _userRepository = userRepository;     
            _refreshTokenRepository = refreshTokenRepository;
        }

        public IUserRepository UserRepository { get => _userRepository; }

        public IRefreshTokenRepository RefreshTokenRepository { get => _refreshTokenRepository; }

        public async Task<int> SaveAsync()
        {
            return await _dbContexnt.SaveChangesAsync();
        }

        public int Save() 
        {
            return _dbContexnt.SaveChanges();
        }

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (disposing)
                _dbContexnt.Dispose();
        }
    }
}
