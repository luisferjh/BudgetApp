using Budget.Application.Interfaces.Generic;
using Budget.Domain.DTOS.Models;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.FinancialProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IFinancialProductService:
        IGenericService<FinancialProductDTO>, 
        IGenericCreateService<CreateFinanceProductDTO>,
        IGenericUpdateService<CreateFinanceProductDTO>
    {
        Task<FinancialProductDTO> GetAsync(string id);
        Task<bool> ProductExistAsync(int id);
        bool ProductExist(int id);
    }
}
