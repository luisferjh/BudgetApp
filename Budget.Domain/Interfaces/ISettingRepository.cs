using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Interfaces
{
    public interface ISettingRepository
    {
        Task<Setting> GetAsync(int id);
        Task<Setting> GetAsync(string serie);
        void UpdateSetting(Setting setting);
    }
}
