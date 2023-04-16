using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SaveLog(LogError log)
        {
            await _unitOfWork.LogRepository.SaveLogAsync(log);
        }

        public async Task SaveLogFile(string data, Exception ex, string controller = "", string service = "")
        {
            await _unitOfWork.LogRepository.SaveFileLogAsync(data, ex, controller, service);
        }
    }
}
