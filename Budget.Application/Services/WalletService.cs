using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapper;

        public WalletService(IUnitOfWork unitOfWork,
            IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapping;
        }

        public async Task<IEnumerable<WalletDTO>> GetFinanceProductUser(int idUser)
        { 
            try
            {
                IEnumerable<Wallet> wallets =  await _unitOfWork.WalletRepository.GetFinanceProductsUserAsync(idUser);
                return _mapper.Map<IEnumerable<WalletDTO>, IEnumerable<Wallet>>(wallets);
            }
            catch (Exception ex)
            {
                await _unitOfWork.LogRepository.SaveLogAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "GetFinanceProductUser",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Key = idUser.ToString()
                });
                await _unitOfWork.SaveAsync();
                throw;
            }
        }

        public async Task<IEnumerable<WalletDTO>> GetFinanceProductUser(string DocUser)
        {
            try
            {
                IEnumerable<Wallet> wallets = await _unitOfWork.WalletRepository.GetFinanceProductsUserAsync(DocUser);
                return _mapper.Map<IEnumerable<WalletDTO>, IEnumerable<Wallet>>(wallets);
            }
            catch (Exception ex)
            {
                await _unitOfWork.LogRepository.SaveLogAsync( new LogError
                {                   
                    DateLog = DateTime.Now,
                    Method = "GetFinanceProductUser",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Key = DocUser                    
                });
                await _unitOfWork.SaveAsync();
                throw;
            }
        }

        public async Task<ResponseServiceDTO> InsertAsync(CreateWalletDTO createWalletDTO)
        {
            try
            {
                Wallet wallet = _mapper.Map<Wallet, CreateWalletDTO>(createWalletDTO);
                await _unitOfWork.WalletRepository.InsertAsync(wallet);
                var result = await _unitOfWork.SaveAsync();

                if (result <= 0)
                    return new ResponseServiceDTO
                    {
                        Result = false,
                        Message = "Ha ocurrido un error guardando el producto financiero del usuario",
                    };
                                
            }
            catch (Exception ex)
            {
                await _unitOfWork.LogRepository.SaveLogAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "InsertAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Data = JsonSerializer.Serialize(createWalletDTO)
                });
                await _unitOfWork.SaveAsync();
                return new ResponseServiceDTO
                {
                    Result = false,
                    Message = "Ha ocurrido un error guardando el producto financiero del usuario",
                };
            }

            return new ResponseServiceDTO
            {
                Result = true,
                Message = "Productop financiero del usuario guardado correctamente",
            };
        }

        public void Update(Wallet wallet)
        {
            _unitOfWork.WalletRepository.Update(wallet);
        }

        public async Task UpdateBalance(int id, decimal valueToAdd)
        {
            var wallet = await _unitOfWork.WalletRepository.GetFinanceProductUserAsync(id);
            wallet.Balance += wallet.Balance + valueToAdd;
            Update(wallet);
        }
    }
}
