using Budget.Application.Interfaces;
using Budget.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class LoginService : ILoginService
    {
        public Task<AuthenticationResultDTO> LoginAsync(LoginDTO loginUser)
        {
            throw new NotImplementedException();
        }
    }
}
