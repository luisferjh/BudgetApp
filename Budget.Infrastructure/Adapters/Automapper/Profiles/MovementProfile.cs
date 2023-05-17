using AutoMapper;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class MovementProfile:Profile
    {
        public MovementProfile()
        {
            CreateMap<MovementDTO, Movement>().ReverseMap();
        }
    }
}
