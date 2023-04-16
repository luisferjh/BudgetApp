using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task SaveLogAsync(LogError logError);
        void SaveLog(LogError logError);

        Task SaveFileLogAsync(string data, Exception ex, string controller = "", string service = "" );
        void SaveFileLog(string data, Exception ex, string controller = "", string service = "");
    }
}
