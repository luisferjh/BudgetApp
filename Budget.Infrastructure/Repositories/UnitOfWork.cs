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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudgetDbContext _dbContexnt;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogRepository _logRepository;
        private readonly ILoadFilesRepository _loadFileRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IFinancialProductRepository _financialProductRepository;
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;
        private readonly IOperationRepository _operationRepository;
        private readonly IAccountEntryRepository _accountEntryRepository;
        private readonly IMovementRepository _movementRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly ISpentRepository _spentRepository;
        private readonly IFixedIncomeRepository _fixedIncomeRepository;

        public UnitOfWork(BudgetDbContext budgetDbContext,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            ILogRepository logRepository,
            ILoadFilesRepository loadFilesRepository,
            IIncomeRepository incomeRepository,
            IWalletRepository walletRepository,
            IFinancialProductRepository financialProductRepository,
            IIncomeCategoryRepository incomeCategoryRepository,
            IOperationRepository operationRepository,
            IAccountEntryRepository accountEntryRepository,
            IMovementRepository movementRepository,
            ISettingRepository settingRepository,
            ISpentRepository spentRepository,
            IFixedIncomeRepository fixedIncomeRepository)
        {
            _dbContexnt = budgetDbContext;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _logRepository = logRepository;
            _loadFileRepository = loadFilesRepository;
            _incomeRepository = incomeRepository;
            _walletRepository = walletRepository;
            _financialProductRepository = financialProductRepository;
            _incomeCategoryRepository = incomeCategoryRepository;
            _operationRepository = operationRepository;
            _accountEntryRepository = accountEntryRepository;
            _movementRepository = movementRepository;
            _settingRepository = settingRepository;
            _spentRepository = spentRepository;
            _fixedIncomeRepository = fixedIncomeRepository;
        }

        public IUserRepository UserRepository { get => _userRepository; }

        public IRefreshTokenRepository RefreshTokenRepository { get => _refreshTokenRepository; }
        public ILogRepository LogRepository { get => _logRepository; }

        public ILoadFilesRepository LoadFilesRepository { get => _loadFileRepository; }

        public IIncomeRepository IncomeRepository { get => _incomeRepository; }
        public ISpentRepository SpentRepository { get => _spentRepository; }

        public IWalletRepository WalletRepository { get => _walletRepository; }
        public IFinancialProductRepository FinancialProductRepository { get => _financialProductRepository; }

        public IIncomeCategoryRepository IncomeCategoryRepository { get => _incomeCategoryRepository;  }
        public IOperationRepository OperationRepository { get => _operationRepository; }
        public IAccountEntryRepository AccountEntryRepository { get => _accountEntryRepository; }
        public IMovementRepository MovementRepository { get => _movementRepository; }
        public ISettingRepository SettingRepository { get => _settingRepository; }

        public IFixedIncomeRepository FixedIncomeRepository { get => _fixedIncomeRepository; }


        //public IGenericRepository<T> GenericRepository<T>() where T : class
        //{
        //    return new ConcreteRepository<T>(_dbContexnt);
        //}


        public async Task<int> SaveAsync()
        {
            try
            {
                return await _dbContexnt.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logRepository.SaveLog(new LogError
                {
                    Data = "",
                    DateLog = DateTime.Now,
                    Method = "SaveAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace
                });
                return -1;
            }
            catch (Exception ex)
            {
                _logRepository.SaveLog(new LogError
                {
                    Data = "",
                    DateLog = DateTime.Now,
                    Method = "SaveAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace
                });
                return -1;
            }
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
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace
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
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace
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
