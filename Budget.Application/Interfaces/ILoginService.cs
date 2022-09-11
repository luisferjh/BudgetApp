using Budget.Domain.DTOs;
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
    }
}
