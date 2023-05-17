using AutoMapper;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.AccountEntry;
using Budget.Infrastructure.DTOS.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class AccountEntryProfile:Profile
    {
        public AccountEntryProfile()
        {
            CreateMap<AccountingEntry, AccountEntriesDTO>().ReverseMap();
        }
    }
}
