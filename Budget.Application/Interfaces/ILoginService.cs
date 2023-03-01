using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface ILoginService
    {
        Task<AuthenticationResultDTO> LoginAsync(LoginDTO loginUser);
        Task<(User, AuthenticationResultDTO)> AuthenticateAsync(LoginDTO loginDTO);
        Task<AuthenticationResultDTO> RefreshTokenAsync(string token, string refreshToken);
    }
}
