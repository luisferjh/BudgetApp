using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface ITokenService
    {
        JwtSettingsDTO GenerateToken(User user);
    }
}
