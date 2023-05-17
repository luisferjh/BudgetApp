using Budget.Application.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Interfaces
{
    public interface ISettingService
    {
        Task<string> GetNextConsecutive(OperationEnum operationEntity);
    }
}
