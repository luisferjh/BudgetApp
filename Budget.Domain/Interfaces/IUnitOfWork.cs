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

        Task<int> SaveAsync();
        int Save();
    }
}
