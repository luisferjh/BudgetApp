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
    public class OperationRepository : IOperationRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public OperationRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public Operation Get(int id)
        {
            return _budgetDbContext.Operations.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Operation> GetAll()
        {
            var operations = _budgetDbContext.Operations.ToList();
            return operations.AsEnumerable();
        }

        public async Task<IEnumerable<Operation>> GetAllAsync()
        {
            var operations = await _budgetDbContext.Operations.ToListAsync();
            return operations.AsEnumerable();
        }

        public async Task<Operation> GetAsync(int id)
        {
            return await _budgetDbContext.Operations.FirstOrDefaultAsync(f => f.Id == id);
        }

        public void Add(Operation model)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Operation model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }        

        public void Update(Operation model)
        {
            throw new NotImplementedException();
        }

        public async Task<Operation> GetAsync(string code)
        {
            return await _budgetDbContext.Operations.FirstOrDefaultAsync(f => f.Code == code);
        }
    }
}
