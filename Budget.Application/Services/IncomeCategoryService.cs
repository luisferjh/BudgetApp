using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.FinancialProduct;
using Budget.Infrastructure.DTOS.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class IncomeCategoryService : IIncomeCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;

        public IncomeCategoryService(
            IUnitOfWork unitOfWork,
            IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }

        public async Task<IEnumerable<IncomeCategoryDTO>> GetAllAsync()
        {
            var incomeCategories = await _unitOfWork.IncomeCategoryRepository.GetAllAsync();
            return _mapping.Map<IEnumerable<IncomeCategoryDTO>, IEnumerable<IncomeCategory>>(incomeCategories);
        }

        public async Task<IncomeCategoryDTO> GetAsync(string id)
        {
            var incomeCategory = await _unitOfWork.IncomeCategoryRepository.GetAsync(id);
            return _mapping.Map<IncomeCategoryDTO, IncomeCategory>(incomeCategory);
        }

        public async Task<IncomeCategoryDTO> GetAsync(int id)
        {
            var incomeCategory = await _unitOfWork.IncomeCategoryRepository.GetAsync(id);
            return _mapping.Map<IncomeCategoryDTO, IncomeCategory>(incomeCategory);
        }

        public async Task<IncomeCategoryDTO> GetByCodeAsync(string code)
        {
            var incomeCategory = await _unitOfWork.IncomeCategoryRepository.GetAsync(code);
            return _mapping.Map<IncomeCategoryDTO, IncomeCategory>(incomeCategory);
        }

        public async Task<int> AddAsync(CreateIncomeCategoryDTO model)
        {
            IncomeCategory incomeCategory = _mapping.Map<IncomeCategory, CreateIncomeCategoryDTO>(model);
            await _unitOfWork.IncomeCategoryRepository.AddAsync(incomeCategory);
            return await _unitOfWork.SaveAsync();
            
        }

        public int Delete(int id)
        {
            _unitOfWork.IncomeCategoryRepository.Delete(id);
            return _unitOfWork.Save();
        }


        public int Update(CreateIncomeCategoryDTO model)
        {
            IncomeCategory incomeCategory = _mapping.Map<IncomeCategory, CreateIncomeCategoryDTO>(model);
            _unitOfWork.IncomeCategoryRepository.Update(incomeCategory);
            return _unitOfWork.Save();
        }

        public async Task<bool> IncomeCategoryExistAsync(int id)
        {
            return await _unitOfWork.IncomeCategoryRepository.IncomeCategoryExistsAsync(id);
        }

        public bool IncomeCategorytExist(int id)
        {
            return _unitOfWork.IncomeCategoryRepository.IncomeCategoryExists(id);
        }
    }
}
