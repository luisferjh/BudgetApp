using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface ILoadFilesRepository
    {
        Task SaveBankFromFile(Stream stream);
        Task AddBanksFromFileAsync(IEnumerable<Bank> banks);
        
    }
}
