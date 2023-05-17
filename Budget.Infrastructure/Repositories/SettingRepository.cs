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
    public class SettingRepository : ISettingRepository
    {
        private readonly BudgetDbContext _budgetDbContext;

        public SettingRepository(BudgetDbContext budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }

        public async Task<Setting> GetAsync(int id)
        {
            return await _budgetDbContext.Settings.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Setting> GetAsync(string serie)
        {
            return await _budgetDbContext.Settings.FirstOrDefaultAsync(f => f.Serie == serie);
        }

        public void UpdateSetting(Setting setting)
        {
            _budgetDbContext.Settings.Update(setting);
        }
    }
}
