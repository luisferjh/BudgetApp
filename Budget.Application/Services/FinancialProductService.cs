using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.FinancialProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class FinancialProductService : IFinancialProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;

        public FinancialProductService(IUnitOfWork unitOfWork, IMapping mapping)          
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }

        public async Task<IEnumerable<FinancialProductDTO>> GetAllAsync()
        {
            var finProducts = await _unitOfWork.FinancialProductRepository.GetAllAsync();
            return _mapping.Map<IEnumerable<FinancialProductDTO>, IEnumerable<FinancialProduct>>(finProducts);
        }

        public async Task<FinancialProductDTO> GetAsync(string id)
        {
            var finProduct = await _unitOfWork.FinancialProductRepository.GetAsync(id);
            return _mapping.Map<FinancialProductDTO, FinancialProduct>(finProduct);
        }

        public async Task<FinancialProductDTO> GetAsync(int id)
        {
            var finProduct = await _unitOfWork.FinancialProductRepository.GetAsync(id);
            return _mapping.Map<FinancialProductDTO, FinancialProduct>(finProduct);
        }

        public async Task<int> AddAsync(CreateFinanceProductDTO model)
        {
            var finProd =_mapping.Map<FinancialProduct, CreateFinanceProductDTO>(model);
            await _unitOfWork.FinancialProductRepository.AddAsync(finProd);
            var result =  await _unitOfWork.SaveAsync();
            return result;
        }

        public int Delete(int id)
        {            
            _unitOfWork.FinancialProductRepository.Delete(id);
            return _unitOfWork.Save();
        }

        public int Update(CreateFinanceProductDTO model)
        {
            var finProd = _mapping.Map<FinancialProduct, CreateFinanceProductDTO>(model);
            _unitOfWork.FinancialProductRepository.Update(finProd);
            return _unitOfWork.Save();
        }

        public async Task<bool> ProductExistAsync(int id)
        {
            return await _unitOfWork.FinancialProductRepository.FinancialProductExistsAsync(id);
        }

        public bool ProductExist(int id)
        {
            return _unitOfWork.FinancialProductRepository.FinancialProductExists(id);
        }
    }
}
