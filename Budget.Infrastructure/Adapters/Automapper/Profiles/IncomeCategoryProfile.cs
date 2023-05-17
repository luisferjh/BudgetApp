using AutoMapper;
using Budget.Domain.Entities;
using Budget.Infrastructure.Common.Utils;
using Budget.Infrastructure.DTOS.FinancialProduct;
using Budget.Infrastructure.DTOS.Incomes;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class IncomeCategoryProfile:Profile
    {
        private readonly IHashids _hashids;

        public IncomeCategoryProfile()
        {
            _hashids = StaticServiceProvider.GetService<IHashids>();

            CreateMap<CreateIncomeCategoryDTO, IncomeCategory>();
            CreateMap<IncomeCategoryDTO, IncomeCategory>()
                .ForMember(incomeCategory => incomeCategory.Id, options => options.MapFrom(incomeCategory => _hashids.Decode(incomeCategory.Id)));
            CreateMap<IncomeCategory, IncomeCategoryDTO>()
               .ForMember(incomeCategory => incomeCategory.Id, options => options.MapFrom(incomeCategory => _hashids.Encode(incomeCategory.Id)));
        }
    }
}
