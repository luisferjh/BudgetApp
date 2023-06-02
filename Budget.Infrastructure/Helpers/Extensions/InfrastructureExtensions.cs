using Budget.Domain.Interfaces;
using Budget.Infrastructure.Adapters.Loads;
using Budget.Infrastructure.Common.Utils;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Budget.Infrastructure.Helpers.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services) 
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<SecurityTools>();
            services.AddTransient<IMapping, AutoMapperImplementation>();
            services.AddTransient<ILoadFilesRepository, LoadFileRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IIncomeCategoryRepository, IncomeCategoryRepository>();
            services.AddTransient<IFixedIncomeRepository, FixedIncomeRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IFinancialProductRepository, FinancialProductRepository>();
            services.AddTransient<IOperationRepository, OperationRepository>();
            services.AddTransient<IAccountEntryRepository, AccountEntryRepository>();
            services.AddTransient<IMovementRepository, MovementRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<ISpentRepository, SpentRepository>();         
        }
    }
}
