using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class AccountEntryRepository : IAccountEntryRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public AccountEntryRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<AccountingEntry> GetAsync(int id)
        {
            return await _budgetDbContext.AccountingEntries.FirstOrDefaultAsync(f => f.Id == id);
        }

        public AccountingEntry Get(int id)
        {
            return _budgetDbContext.AccountingEntries.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<AccountingEntry> GetAll()
        {
            var accountEntries = _budgetDbContext.AccountingEntries.ToList();
            return accountEntries.AsEnumerable();
        }

        public async Task<IEnumerable<AccountingEntry>> GetAllAsync()
        {
            var accountEntries = await _budgetDbContext.AccountingEntries.ToListAsync();
            return accountEntries.AsEnumerable();
        }    

        public void Add(AccountingEntry model)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(AccountingEntry model)
        {
            throw new NotImplementedException();
        }              

        public void Update(AccountingEntry model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountingEntry> GetAsync(string code)
        {
            return await _budgetDbContext.AccountingEntries.FirstOrDefaultAsync(f => f.Code == code);
        }
    }
}
