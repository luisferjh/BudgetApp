using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface ILogService
    {
        Task SaveLog(LogError log);
        Task SaveLogFile(string data, Exception ex, string controller = "", string service = "");
    }
}
