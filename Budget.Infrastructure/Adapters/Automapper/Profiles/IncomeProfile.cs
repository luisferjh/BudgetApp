using AutoMapper;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using Budget.Infrastructure.Common.Utils;
using Budget.Infrastructure.DTOS.FixedIncomes;
using Budget.Infrastructure.DTOS.Incomes;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class IncomeProfile:Profile
    {
        private readonly IHashids _hashids;
        public IncomeProfile()
        {
            _hashids = StaticServiceProvider.GetService<IHashids>();

            CreateMap<CreateIncomeDTO, Income>();                        
            CreateMap<Income, IncomeDTO>()
                .ForMember(income => income.Id, options => options.MapFrom(income => _hashids.Encode(income.Id)));

            CreateMap<IncomeDTO, Income>()
             .ForMember(income => income.Id, options => options.MapFrom(income => _hashids.Decode(income.Id)));
     
            CreateMap<FixedIncome, FixedIncomeDTO>().ReverseMap();
        }
    }
}
