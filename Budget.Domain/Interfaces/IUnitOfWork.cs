using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IUnitOfWork
    {     
        IUserRepository UserRepository { get; }        

        Task SaveAsync();
    }
}
