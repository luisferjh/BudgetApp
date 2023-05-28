using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILogRepository LogRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        ILoadFilesRepository LoadFilesRepository { get; }
        IIncomeRepository IncomeRepository { get; }
        IWalletRepository WalletRepository { get; }   
        IFinancialProductRepository FinancialProductRepository { get; }
        IIncomeCategoryRepository IncomeCategoryRepository { get; }
        IOperationRepository OperationRepository { get; }
        IAccountEntryRepository AccountEntryRepository { get; }
        IMovementRepository MovementRepository { get; }
        ISettingRepository SettingRepository { get; }
        ISpentRepository SpentRepository { get; }
        IFixedIncomeRepository FixedIncomeRepository { get; }
        //IGenericRepository<T> GenericRepository<T>() where T : class;


        Task<int> SaveAsync();
        int Save();
    }
}
