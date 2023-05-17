using Budget.Application.Interfaces.Generic;
using Budget.Infrastructure.DTOS.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IIncomeCategoryService: 
        IGenericService<IncomeCategoryDTO>,
        IGenericCreateService<CreateIncomeCategoryDTO>,
        IGenericUpdateService<CreateIncomeCategoryDTO>
    {
        Task<IncomeCategoryDTO> GetAsync(string id);
        Task<IncomeCategoryDTO> GetByCodeAsync(string code);
        Task<bool> IncomeCategoryExistAsync(int id);
        bool IncomeCategorytExist(int id);

    }
}
