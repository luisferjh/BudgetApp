using AutoMapper;
using Budget.Domain.Entities;
using Budget.Infrastructure.Common.Utils;
using Budget.Infrastructure.DTOS.Incomes;
using Budget.Infrastructure.DTOS.Operation;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class OperationProfile: Profile
    {   
        public OperationProfile()
        {          
            CreateMap<Operation, OperationDTO>().ReverseMap() ;
        }
    }
}
