using Budget.Domain.DTOS.Models;
using Budget.Domain.DTOS.user;
using Budget.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<ResponseServiceDTO> InsertAsync(UserCreateDTO model);             
        Task<ResponseServiceDTO> DeleteAsync(string email);
    }
}
