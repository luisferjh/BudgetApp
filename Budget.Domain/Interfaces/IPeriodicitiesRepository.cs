using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IPeriodicitiesRepository
    {
        Task<IEnumerable<Periodicity>> GetAllAsync();
        Task<Periodicity> GetAsync(int id);
    }
}
