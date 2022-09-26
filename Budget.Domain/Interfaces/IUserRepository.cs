using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> Get(string username);
    }
}
