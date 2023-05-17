using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IWalletRepository
    {   
        Task<IEnumerable<Wallet>> GetFinanceProductsUserAsync(int idUser);
        Task<IEnumerable<Wallet>> GetFinanceProductsUserAsync(string DocUser);
        Task<Wallet> GetFinanceProductUserAsync(int id);        
        Task InsertAsync(Wallet wallet);
        void Update(Wallet wallet);
    }
}
