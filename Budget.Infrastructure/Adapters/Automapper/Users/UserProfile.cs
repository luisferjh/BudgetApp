using AutoMapper;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserCreateDTO, UserDto>();
        }
    }
}
