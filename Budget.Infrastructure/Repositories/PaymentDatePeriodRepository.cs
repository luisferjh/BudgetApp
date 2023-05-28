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
    public class PaymentDatePeriodRepository : IPaymentDatePeriodRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public PaymentDatePeriodRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<IEnumerable<PaymentDatePeriod>> GetAllAsync()
        {
            var paymentDatePeriods = await _budgetDbContext.PaymentDatePeriods.ToListAsync();
            return paymentDatePeriods.AsEnumerable();
        }

        public async Task<PaymentDatePeriod> GetAsync(int id)
        {
            return await _budgetDbContext.PaymentDatePeriods.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
