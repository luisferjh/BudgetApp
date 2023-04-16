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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudgetDbContext _dbContexnt;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogRepository _logRepository;
        private readonly ILoadFilesRepository _loadFileRepository;

        public UnitOfWork(BudgetDbContext budgetDbContext,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            ILogRepository logRepository,
            ILoadFilesRepository loadFilesRepository)
        {
            _dbContexnt = budgetDbContext;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _logRepository = logRepository;
            _loadFileRepository = loadFilesRepository;
        }

        public IUserRepository UserRepository { get => _userRepository; }

        public IRefreshTokenRepository RefreshTokenRepository { get => _refreshTokenRepository; }
        public ILogRepository LogRepository { get => _logRepository; }

        public ILoadFilesRepository LoadFilesRepository { get => _loadFileRepository; }

        public async Task<int> SaveAsync()
        {
            return await _dbContexnt.SaveChangesAsync();
        }

        public int Save() 
        {
            try
            {
                return _dbContexnt.SaveChanges();
            }         
            catch (DbUpdateException ex)
            {                
                _logRepository.SaveLog(new LogError
                {
                    Data = "",
                    DateLog = DateTime.Now,
                    Method = "LoginController",
                    Trace = ex.Message
                });
                return -1;
            }
            catch (Exception ex)
            {
                _logRepository.SaveLog(new LogError
                {
                    Data = "",
                    DateLog = DateTime.Now,
                    Method = "LoginController",
                    Trace = ex.Message
                });
                return -1;
            }
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
