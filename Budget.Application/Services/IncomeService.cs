using Budget.Application.Interfaces;
using Budget.Application.Types;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.Incomes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class IncomeService:IIncomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettingService _settingService;
        private readonly IWalletService _walletService;
        private readonly IMovementService _movementService;
        private readonly IMapping _mapping;

        public IncomeService(
            IUnitOfWork unitOfWork,
            ISettingService settingService,
            IWalletService walletService,          
            IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _settingService = settingService;
            _walletService = walletService;            
            _mapping = mapping;
        }

        public async Task<ResponseServiceDTO> AddIncomeAsync(CreateIncomeDTO createIncomeDTO)
        {
            ResponseServiceDTO responseDTO = new ResponseServiceDTO();
            try
            {
                Income income = _mapping.Map<Income, CreateIncomeDTO>(createIncomeDTO);
                income.TransactionNumber = await _settingService.GetNextConsecutive(OperationEnum.Income);
                income.IdState = (int)StatesEnum.ACTIVE;
                income.IdOperation = (int)OperationsEnum.INCOME;
                await _unitOfWork.IncomeRepository.AddAsync(income);

                await _walletService.UpdateAddBalance(income.IdFinancialProduct, income.Amount);

                Operation operation = await _unitOfWork.OperationRepository.GetAsync("INCOME");
                Wallet wallet = await _unitOfWork.WalletRepository.GetFinanceProductUserAsync(income.IdFinancialProduct);
                AccountingEntry accountingEntry = await _unitOfWork.AccountEntryRepository.GetAsync("DEB");
                User user = await _unitOfWork.UserRepository.GetAsync(income.IdUser);
                Movement lastMovement = await _unitOfWork.MovementRepository.GetLastTransactionByWalletAsync(wallet.AccountNumber);

                Movement movement = new Movement 
                {
                    IdAccountingEntry = accountingEntry.Id,
                    IdOperation = operation.Id,
                    IdPreviousTransaction = lastMovement != null ? lastMovement.Id : null,
                    TransactionNumber = income.TransactionNumber,
                    AccountNumber = wallet.AccountNumber,
                    DNI = user.DNI,
                    Amount = income.Amount,
                };

                await _unitOfWork.MovementRepository.AddAsync(movement);

                int result = await _unitOfWork.SaveAsync();

                if (result <= 0)
                {
                    responseDTO.Result = false;
                    responseDTO.Message = "an error has occurred registering an income";
                    responseDTO.Response = createIncomeDTO;

                    return responseDTO;
                }

                responseDTO.Result = true;
                responseDTO.Message = "Income registered succesfully";
            }// tener presente capturar la excepcion de mapeo de automapper
            catch (Exception ex)
            {
                await _unitOfWork.LogRepository.SaveLogAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "AddIncomeAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application,
                    Data = JsonSerializer.Serialize(createIncomeDTO)
                }) ;
                await _unitOfWork.SaveAsync();

                responseDTO.Result = false;
                responseDTO.Message = "an error has occurred registering an income";
                responseDTO.Response = createIncomeDTO;

                return responseDTO;
            }

            return responseDTO;
        }

        public async Task<IEnumerable<IncomeDTO>> GetIncomesByUser(int idUser, int year, int idIncomeCategory)
        {
            IEnumerable<Income> incomes = await _unitOfWork.IncomeRepository.GetIncomesByUser(idUser, year, idIncomeCategory);           
            IEnumerable<IncomeDTO> incomesDtos = _mapping.Map<IEnumerable<IncomeDTO>, IEnumerable<Income>>(incomes);
            return incomesDtos;
        }
    }
}
