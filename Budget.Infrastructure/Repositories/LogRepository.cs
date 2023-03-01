using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace Budget.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly BudgetDbContext _dbContext;
        public LogRepository(BudgetDbContext db)
        {
            _dbContext = db;
        }

        public void SaveLog(LogError logError)
        {
            try
            {
                //_dbContext.LogErrors.Add(logError);
                _dbContext.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                // save in file in disk
            }
            
        }
    }
}
