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
    public class MovementRepository : IMovementRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public MovementRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public void Add(Movement model)
        {
            _budgetDbContext.Movements.Add(model);
        }

        public async Task AddAsync(Movement movement)
        {
            await _budgetDbContext.Movements.AddAsync(movement);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movement Get(int id)
        {
            return _budgetDbContext.Movements.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Movement> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Movement> GetAsync(int id)
        {
            return await _budgetDbContext.Movements.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Movement> GetLastTransactionByWalletAsync(string accountNumber)
        {
            return await _budgetDbContext.Movements
                .OrderByDescending(od => od.CreatedDate)
                .FirstOrDefaultAsync(f => f.AccountNumber == accountNumber);
        }

        public void Update(Movement model)
        {
            throw new NotImplementedException();
        }
    }
}
