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
    public class FinancialProductProfile:Profile
    {
        private readonly IHashids _hashids;
        public FinancialProductProfile()
        {
            _hashids = StaticServiceProvider.GetService<IHashids>();

            CreateMap<CreateFinanceProductDTO, FinancialProduct>();
            CreateMap<FinancialProductDTO, FinancialProduct>()
                .ForMember(finProd => finProd.Id, options => options.MapFrom(finProd => _hashids.Decode(finProd.Id)));
            CreateMap<FinancialProduct, FinancialProductDTO>()
               .ForMember(finProd => finProd.Id, options => options.MapFrom(finProd => _hashids.Encode(finProd.Id)));
        }
    }
}
