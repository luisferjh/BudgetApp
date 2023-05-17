using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly BudgetDbContext _dbContext;
        public LogRepository(BudgetDbContext db)
        {
            _dbContext = db;
        }

        public async Task SaveFileLogAsync(string data, Exception ex, string controller = "", string service = "")
        {            
            // - Directory by year
            // - Directory by month
            // - Directory by day
            string pathDirectory = GetDirectoryLog();
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            string nameFile = $"{time.Hour}{time.Minute}{time.Second}.txt";
            pathDirectory += $"{Path.DirectorySeparatorChar}{nameFile}";
            var file = new FileInfo(pathDirectory);
            using (var fileStream = file.Create())
            {
                string text = $"- Data: {data} \n " +
                    $"- Exception: {ex.Message} \n " +
                    $"- Trace: {ex.InnerException} \n" +
                    $"- Controller: {controller} \n" +
                    $"- Service: {service}";

                byte[] textByteArray = Encoding.Default.GetBytes(text);
                await fileStream.WriteAsync(textByteArray, 0, textByteArray.Length);
            }

        }
        public void SaveLog(LogError logError)
        {
            try
            {
                _dbContext.LogErrors.Add(logError);
                //_dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // save in file in disk
                SaveFileLog(logError.Data, ex, logError.Method, logError.Key);
            }
        }

        public async Task SaveLogAsync(LogError logError)
        {
            try
            {
                _dbContext.LogErrors.Add(logError);
                //await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // save in file in disk
                await SaveFileLogAsync(logError.Data, ex, logError.Method, logError.Key);
            }

        }

        private static string GetDirectoryLog()
        {
            string fullPath = "";           
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            DirectoryInfo dirLog = new DirectoryInfo(".");
       
            string pathRelativeFolder = $@"{Path.DirectorySeparatorChar}{date.Year}" +
                        $"{Path.DirectorySeparatorChar}{date.Month}" +
                        $"{Path.DirectorySeparatorChar}{date.Day}";

            fullPath = $@"{dirLog.FullName}{pathRelativeFolder}";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
                                
            return fullPath;          
        }

        public void SaveFileLog(string data, Exception ex, string controller = "", string service = "")
        {
            // - Directory by year
            // - Directory by month
            // - Directory by day
            string pathDirectory = GetDirectoryLog();
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            string nameFile = $"{time.Hour}{time.Minute}{time.Second}.txt";
            pathDirectory += $"{Path.DirectorySeparatorChar}{nameFile}";
            var file = new FileInfo(pathDirectory);
            using (var fileStream = file.Create())
            {
                string text = $"- Data: {data} \n " +
                    $"- Exception: {ex.Message} \n " +
                    $"- Trace: {ex.InnerException} \n" +
                    $"- Controller: {controller} \n" +
                    $"- Service: {service}";

                byte[] textByteArray = Encoding.Default.GetBytes(text);
                fileStream.Write(textByteArray, 0, textByteArray.Length);
            }
        }
    }
}
