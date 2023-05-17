using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IAccountEntryRepository: IGenericRepository<AccountingEntry>
    {
        Task<AccountingEntry> GetAsync(string code);
    }
}
