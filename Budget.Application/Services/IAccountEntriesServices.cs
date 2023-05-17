using Budget.Application.Interfaces.Generic;
using Budget.Infrastructure.DTOS.AccountEntry;
using Budget.Infrastructure.DTOS.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public interface IAccountEntriesServices : IGenericService<AccountEntriesDTO>
    {
    }
}
