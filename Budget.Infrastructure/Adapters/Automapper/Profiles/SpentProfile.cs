using AutoMapper;
using Budget.Domain.Entities;
using Budget.Infrastructure.Common.Utils;
using Budget.Infrastructure.DTOS.Incomes;
using Budget.Infrastructure.DTOS.Spents;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class SpentProfile:Profile
    {
        private readonly IHashids _hashids;
        public SpentProfile()
        {
            _hashids = StaticServiceProvider.GetService<IHashids>();

            CreateMap<CreateSpentDTO, Spent>();
            CreateMap<Spent, SpentDTO>()
                .ForMember(spent => spent.Id, options => options.MapFrom(spent => _hashids.Encode(spent.Id)));

            CreateMap<IncomeDTO, Income>()
             .ForMember(spent => spent.Id, options => options.MapFrom(spent => _hashids.Decode(spent.Id)));

        }

    }
}
