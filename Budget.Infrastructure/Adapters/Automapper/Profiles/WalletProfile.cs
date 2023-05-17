using AutoMapper;
using Budget.Domain.Entities;
using Budget.Infrastructure.DTOS.Incomes;
using Budget.Infrastructure.DTOS.Wallet;
using System;
using System.Collections.Generic;


namespace Budget.Infrastructure.Adapters.Automapper.Profiles
{
    public class WalletProfile: Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, WalletDTO>().ReverseMap();
            CreateMap<CreateWalletDTO, Wallet>();
        }
    }
}
