using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface ISpentRepository
    {
        Task AddAsync(Spent model);

        void Add(Spent model);

        Task<IEnumerable<Spent>> GetSpentsByUser(int idUser, int year, int idSpentDetail);
    }
}
