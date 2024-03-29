﻿using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface IIncomeRepository
    {
        Task AddAsync(Income model);

        void Add(Income model);

        Task<IEnumerable<Income>> GetIncomesByUser(int idUser, int year, int idIncomeCategory);
    }
}
