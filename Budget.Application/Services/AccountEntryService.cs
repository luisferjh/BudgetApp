using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.AccountEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class AccountEntryService : IAccountEntriesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;

        public AccountEntryService(
            IUnitOfWork unitOfWork,
            IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }

        public async Task<IEnumerable<AccountEntriesDTO>> GetAllAsync()
        {
            IEnumerable<AccountingEntry> accountingEntries = await _unitOfWork.AccountEntryRepository.GetAllAsync();
            return _mapping.Map<IEnumerable<AccountEntriesDTO>, IEnumerable<AccountingEntry>>(accountingEntries);
        }

        public async Task<AccountEntriesDTO> GetAsync(int id)
        {
            AccountingEntry accountEntry = await _unitOfWork.AccountEntryRepository.GetAsync(id);
            return _mapping.Map<AccountEntriesDTO, AccountingEntry>(accountEntry);
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}
