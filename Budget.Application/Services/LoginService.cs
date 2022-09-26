using Budget.Application.Interfaces;
using Budget.Domain.DTOs;
using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AuthenticationResultDTO> LoginAsync(LoginDTO loginUser)
        {
            throw new NotImplementedException();
        }
    }
}
