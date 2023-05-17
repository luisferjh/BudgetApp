using AutoMapper;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using Budget.Infrastructure.Common.Utils;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common
{
    public class UserProfile:Profile
    {
        private readonly IHashids _hashids;

        public UserProfile()
        {
            _hashids = StaticServiceProvider.GetService<IHashids>();

            CreateMap<UserDto, User>()
               .ForMember(user => user.Id, options => options.MapFrom(userDto => _hashids.Decode(userDto.Id)));
            CreateMap<User, UserDto>()
                 .ForMember(userDto => userDto.Id, options => options.MapFrom(user => _hashids.Encode(user.Id)));
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserCreateDTO, UserDto>();
           
        }
    }
}
