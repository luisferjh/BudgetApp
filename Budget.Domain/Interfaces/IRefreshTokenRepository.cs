using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> Get(string jti);
        Task AddAsync(RefreshToken model);
        void Add(RefreshToken model);
        void Update(RefreshToken model);
    }
}
