using AutoMapper;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class IncomeProfile:Profile
    {
        public IncomeProfile()
        {
            CreateMap<CreateIncomeDTO, Income>();                        
        }
    }
}
