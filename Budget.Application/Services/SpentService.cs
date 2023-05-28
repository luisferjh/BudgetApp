using Budget.Application.Interfaces;
using Budget.Application.Types;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.Incomes;
using Budget.Infrastructure.DTOS.Spents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class SpentService : ISpentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;
        private readonly ISettingService _settingService;
        private readonly IWalletService _walletService;

        public SpentService(
            IUnitOfWork unitOfWork,
            IMapping mapping,
            ISettingService settingService,
            IWalletService walletService)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
            _settingService = settingService;
            _walletService = walletService;
        }

        public async Task<ResponseServiceDTO> AddSpentAsync(CreateSpentDTO createSpentDTO)
        {
            ResponseServiceDTO responseDTO = new ResponseServiceDTO();
            try
            {
                Spent spent = _mapping.Map<Spent, CreateSpentDTO>(createSpentDTO);
                spent.TransactionNumber = await _settingService.GetNextConsecutive(OperationEnum.Spent);
                await _unitOfWork.SpentRepository.AddAsync(spent);

                await _walletService.UpdateSubstractBalance(spent.IdFinancialProduct, spent.Amount);

                Operation operation = await _unitOfWork.OperationRepository.GetAsync("SPENT");
                Wallet wallet = await _unitOfWork.WalletRepository.GetFinanceProductUserAsync(spent.IdFinancialProduct);
                AccountingEntry accountingEntry = await _unitOfWork.AccountEntryRepository.GetAsync("CRED");
                User user = await _unitOfWork.UserRepository.GetAsync(spent.IdUser);
                Movement lastMovement = await _unitOfWork.MovementRepository.GetLastTransactionByWalletAsync(wallet.AccountNumber);

                Movement movement = new Movement
                {
                    IdAccountingEntry = accountingEntry.Id,
                    IdOperation = operation.Id,
                    IdPreviousTransaction = lastMovement != null ? lastMovement.Id : null,
                    TransactionNumber = spent.TransactionNumber,
                    AccountNumber = wallet.AccountNumber,
                    DNI = user.DNI,
                    Amount = spent.Amount,
                };

                await _unitOfWork.MovementRepository.AddAsync(movement);

                int result = await _unitOfWork.SaveAsync();

                if (result <= 0)
                {
                    responseDTO.Result = false;
                    responseDTO.Message = "an error has occurred registering an spent";
                    responseDTO.Response = createSpentDTO;

                    return responseDTO;
                }

                responseDTO.Result = true;
                responseDTO.Message = "Spent registered succesfully";
            }// tener presente capturar la excepcion de mapeo de automapper
            catch (Exception ex)
            {
                await _unitOfWork.LogRepository.SaveLogAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "AddSpentAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Data = JsonSerializer.Serialize(createSpentDTO)
                });
                await _unitOfWork.SaveAsync();

                responseDTO.Result = false;
                responseDTO.Message = "an error has occurred registering an spent";
                responseDTO.Response = createSpentDTO;

                return responseDTO;
            }

            return responseDTO;
        }

        public async Task<IEnumerable<SpentDTO>> GetSpentsByUser(int idUser, int year, int idSpentCategory)
        {
            IEnumerable<Spent> spents = await _unitOfWork.SpentRepository.GetSpentsByUser(idUser, year, idSpentCategory);
            IEnumerable<SpentDTO> spentsDtos = _mapping.Map<IEnumerable<SpentDTO>, IEnumerable<Spent>>(spents);
            return spentsDtos;
        }
    }
}
