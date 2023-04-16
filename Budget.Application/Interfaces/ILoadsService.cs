using Budget.Domain.DTOS.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface ILoadsService
    {
        ResponseServiceDTO LoadBanks(IFormFile file);
    }
}
