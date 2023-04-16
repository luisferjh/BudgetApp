using Budget.Application.Interfaces;
using Budget.Infrastructure.Common.Utils;
using Budget.Domain.DTOS.Models;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Budget.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SecurityTools _st;
        private readonly IMapping _mapping;

        public UserService(IUnitOfWork unitOfWork, SecurityTools st, IMapping mapping)           
        {
            _unitOfWork = unitOfWork;
            _st = st;
            _mapping = mapping;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var userDtos = _mapping.Map<List<UserDto>, List<User>>(users.ToList());
            return userDtos;
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            var userDto = _mapping.Map<UserDto, User>(user);
            return userDto;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _unitOfWork.UserRepository.Get(email);
            var userDto = _mapping.Map<UserDto, User>(user);
            return userDto;
        }

        public async Task<ResponseServiceDTO> InsertAsync(UserCreateDTO model)
        {
            try
            {               
                model.CreatedDate = DateTime.Now;
                model.State = 1;
                model.Password = _st.EncryptPlainText(model.Password);
                //model.Password = SecurityTools.EncryptPlainText(model.Password);
                
                var user = _mapping.Map<User, UserCreateDTO>(model);
                //var user = _mapper.Map<UserDto, User>(model);
                await _unitOfWork.UserRepository.AddAsync(user);
                int result = await _unitOfWork.SaveAsync();

                if (result > 0)                
                    return new ResponseServiceDTO
                    {
                        Message = "User registered successfully",
                        Result = true,
                        Response = user,
                    };                
                else                 
                    return new ResponseServiceDTO
                    {
                        Message = "Error occurred",
                        Result = false,
                        Response = model,
                    };
                               
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Message = ex.Message,
                    Result = false,
                    Response = model,
                };
            }

        }        
        
        public async Task<ResponseServiceDTO> DeleteAsync(string email)
        {
            try
            {
                User userDB = await _unitOfWork.UserRepository.Get(email);

                if (userDB == null)
                {
                    return new ResponseServiceDTO
                    {
                        Message = "User not found",
                        Result = false,
                        Response = null,
                    };
                }

                _unitOfWork.UserRepository.Deactivate(userDB);
                var result = await _unitOfWork.SaveAsync();


                if (result > 0)
                {
                    return new ResponseServiceDTO
                    {
                        Message = "User has been invalidated",
                        Result = true,
                        Response = null,
                    };
                }
                else
                {
                    return new ResponseServiceDTO
                    {
                        Message = "Error occurred",
                        Result = false,
                        Response = null,
                    };
                }                

            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
