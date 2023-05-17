using Budget.Application.Interfaces;
using Budget.Application.Types;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Dictionary<OperationEnum, string> _seriesSettingEntity = new Dictionary<OperationEnum, string>();

        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _seriesSettingEntity.Add(OperationEnum.Income, "INC");
            _seriesSettingEntity.Add(OperationEnum.Spent, "SPN");
            _seriesSettingEntity.Add(OperationEnum.Transfer, "TRA");
            _seriesSettingEntity.Add(OperationEnum.Loan, "LOA");
            _seriesSettingEntity.Add(OperationEnum.Saving, "SAV");
        }

        public async Task<string> GetNextConsecutive(OperationEnum operationEntity)
        {           
            string serie = _seriesSettingEntity.GetValueOrDefault(operationEntity);

            Setting setting = await _unitOfWork.SettingRepository.GetAsync(serie);
            string consecutive = $"{setting.Serie}{setting.Value}";
            long currentConsecutive = long.Parse(setting.Value);
            long nextConsecutive = currentConsecutive++;
            setting.Value = nextConsecutive.ToString();
            _unitOfWork.SettingRepository.UpdateSetting(setting);
           
            return consecutive;
        }      

    }
}
