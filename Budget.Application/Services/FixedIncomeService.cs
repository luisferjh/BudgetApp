using Budget.Application.Interfaces;
using Budget.Application.Types;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.FixedIncomes;
using Budget.Infrastructure.DTOS.Incomes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class FixedIncomeService : IFixedIncomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;
        private readonly IIncomeService _incomeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISettingService _settingService;

        public FixedIncomeService(
            IUnitOfWork unitOfWork,
            IMapping mapping,
            IIncomeService incomeService,
            IHttpContextAccessor httpContextAccessor,
            ISettingService settingService)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
            _incomeService = incomeService;
            _httpContextAccessor = httpContextAccessor;
            _settingService = settingService;
        }
        public async Task<ResponseServiceDTO> AddFixedIncomeAsync(CreateFixedIncomeDTO fixedIncomeDto)
        {
            try
            {
                var createIncome = _mapping.Map<FixedIncome, CreateFixedIncomeDTO>(fixedIncomeDto);
                await _unitOfWork.FixedIncomeRepository.InsertFixedIncomeAsync(createIncome);
                var resultSave = await _unitOfWork.SaveAsync();
                if (resultSave <= 0)
                    return new ResponseServiceDTO
                    {
                        Result = false,
                        Message = "An error has ocurred saving the fixed income"
                    };

                return new ResponseServiceDTO 
                {
                    Result = true,
                    Message = "Fixed income saved succesfully"
                };                                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FixedIncomeDTO>> GetAllFixedIncomesAsync(int idUser)
        {
            IEnumerable<FixedIncome> fixedIncomes = await _unitOfWork.FixedIncomeRepository.GetAllByUserAsync(idUser);
            return _mapping.Map<IEnumerable<FixedIncomeDTO>, IEnumerable<FixedIncome>>(fixedIncomes);
        }

        public async Task<FixedIncomeDTO> GetAsync(int id)
        {
            FixedIncome fixedIncome = await _unitOfWork.FixedIncomeRepository.GetAsync(id);
            return _mapping.Map<FixedIncomeDTO, FixedIncome>(fixedIncome);
        }

        public async Task<ResponseServiceDTO> RunFixedIncomeAsync()
        {            
            List<CreateIncomeDTO> incomes = new();      
            ResponseServiceDTO responseService = new();
            try
            {
                var userClaims = _httpContextAccessor.HttpContext.User;
                Claim emailClaim = userClaims.FindFirst(ClaimTypes.Email);
                var user = await _unitOfWork.UserRepository.Get(emailClaim.Value);
                IEnumerable<FixedIncome> fixedIncomesCollection = await _unitOfWork.FixedIncomeRepository.GetAllByUserAsync(user.Id);
                int fixedIncomeCount = fixedIncomesCollection.Count();
                int fixedIncomeProcessed = 0;
                int fixedIncomeFailed = 0;
                foreach (var fixedIncome in fixedIncomesCollection.ToList())
                {
                    CreateIncomeDTO income = new CreateIncomeDTO
                    {
                        IdIncomeCategory = fixedIncome.IdIncomeCategory,
                        IdUser = user.Id,
                        IdFinancialProduct = fixedIncome.IdWallet.Value,
                        Amount = fixedIncome.Amount,
                        Year = DateTime.Now.Year,
                        Description = "Fixed income"
                    };

                    incomes.Add(income);

                    var responseServiceIncome = await _incomeService.AddIncomeAsync(income);
                    if (responseServiceIncome.Result)
                        fixedIncomeProcessed += 1;
                    else
                        fixedIncomeFailed += 1;
                }

                if (fixedIncomeFailed == fixedIncomesCollection.Count())
                {
                    responseService.Result = false;
                    responseService.Message = "An error has occurred processing the incomes";
                    responseService.Response = new
                    {
                        Processed = fixedIncomeProcessed,
                        Failed = fixedIncomeFailed
                    };
                }
                else 
                {
                    responseService.Result = true;
                    responseService.Message = "Fixed incomes processed succesfully";
                    responseService.Response = new
                    {
                        Processed = fixedIncomeProcessed,
                        Failed = fixedIncomeFailed
                    };
                }
                       
                return responseService;
            }
            catch (Exception ex)
            {
                await _unitOfWork.LogRepository.SaveLogAsync(new LogError
                {
                    DateLog = DateTime.Now,
                    Method = "RunFixedIncomeAsync",
                    MessageError = ex.Message,
                    StackTrace = ex.StackTrace,
                    Layer = Layers.Application
                    
                });
                await _unitOfWork.SaveAsync();

                responseService.Result = false;
                responseService.Message = "an error has occurred registering fixed incomes";
                
                return responseService;
            }
            
        }
    }
}
