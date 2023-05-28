using Budget.Application.Interfaces;
using Budget.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Helpers
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ILoadsService, LoadsService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IIncomeCategoryService, IncomeCategoryService>();
            services.AddTransient<IFixedIncomeService, FixedIncomeService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<ISpentService, SpentService>();
            services.AddTransient<IFinancialProductService, FinancialProductService>();
            services.AddTransient<IAccountEntriesServices, AccountEntryService>();
        }
    }
}
