using AutoMapper;
using Budget.Infrastructure.Adapters.Automapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Budget.Infrastructure.Common
{
    public class AutomapperSingleton
    {
        private static IMapper mapper = null;
        private static string CreatedOn;
        private AutomapperSingleton()
        {
            CreatedOn = DateTime.Now.ToString();
        }

        public static IMapper GetMapper() 
        {
            if (mapper == null)
            {
                var configMapper = new MapperConfiguration(cfg => {
                    cfg.AddProfile<UserProfile>();
                    cfg.AddProfile<IncomeProfile>();
                    cfg.AddProfile<WalletProfile>();
                    cfg.AddProfile<FinancialProductProfile>();
                    cfg.AddProfile<IncomeCategoryProfile>();
                    cfg.AddProfile<AccountEntryProfile>();
                    cfg.AddProfile<OperationProfile>();
                    cfg.AddProfile<MovementProfile>();
                    cfg.AddProfile<SpentProfile>();
                });

                mapper = configMapper.CreateMapper();                
                return mapper;
            }
            else 
            {
                return mapper;
            }            
        }
    }
}
