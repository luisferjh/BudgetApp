using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletDTO>> GetFinanceProductUser(int idUser);
        Task<IEnumerable<WalletDTO>> GetFinanceProductUser(string DocUser);
        Task<ResponseServiceDTO> InsertAsync(CreateWalletDTO createWalletDTO);
        void Update(Wallet wallet);
        Task UpdateBalance(int id, decimal valueToAdd);
    }
}
