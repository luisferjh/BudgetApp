using Budget.Application.Interfaces;
using Budget.Application.Services;
using Budget.Infrastructure.Common.Utils;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.Data;
using Budget.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Budget.Infrastructure.Common.Configs;
using Budget.Infrastructure.Adapters.Loads;
using HashidsNet;
using Microsoft.OpenApi.Models;

namespace BudgetApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            // Add services to the container.
            services.AddControllers();
            
            // descomentar cuando tengamos errores de referencias ciclicas
            //services.AddControllers().AddJsonOptions(x => 
            //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
          
            //services.Configure<KeyValuesConfiguration>(Configuration)
            //    .AddSingleton(sp => sp.GetRequiredService<IOptions<KeyValuesConfiguration>>().Value);
            services.Configure<KeyValuesConfiguration>(options => Configuration.GetSection("KeyValuesConfiguration").Bind(options));
            services.Configure<JwtSettings>(options => Configuration.GetSection("JwtSettings").Bind(options));
            //services.AddOptions();

            services.AddDbContext<BudgetDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Connection")));


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration.GetValue<string>("JwtSettings:Issuer"),
                ValidAudience = Configuration.GetValue<string>("JwtSettings:Issuer"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSettings:SecretKey")))
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>              
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenValidationParameters;
            });

            //services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IUserRepository, UserRepository>();          
            services.AddTransient<ILogRepository, LogRepository>();          
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();          
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<SecurityTools>();
            services.AddTransient<IMapping, AutoMapperImplementation>();
            services.AddTransient<ILoadsService, LoadsService>();
            services.AddTransient<ILoadFilesRepository, LoadFileRepository>();
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IIncomeCategoryService, IncomeCategoryService>();
            services.AddTransient<IIncomeCategoryRepository, IncomeCategoryRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IFinancialProductService, FinancialProductService>();
            services.AddTransient<IFinancialProductRepository, FinancialProductRepository>();
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IOperationRepository, OperationRepository>();
            services.AddTransient<IAccountEntriesServices, AccountEntryService>();
            services.AddTransient<IAccountEntryRepository, AccountEntryRepository>();
            //services.AddTransient<IMovementService, MovementService>();
            services.AddTransient<IMovementRepository, MovementRepository>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<ISettingRepository, SettingRepository>();

            services.AddSingleton<IHashids>(new Hashids("ujgsxeqqsd", 11));

            // initialize static service provider
            StaticServiceProvider.BuildProvider(services);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("isAdmin"));
                options.AddPolicy("IsUser", policy => policy.RequireClaim("isUser"));
                // para validar cualquiera de los roles en el endpoint
                options.AddPolicy("IsAdminOrUser", policy => policy.RequireClaim("isAdminUser","isAdmin","isUser"));
                // para hacer autenticacion multiroles
                //options.AddPolicy("IsAdminUser", policy => policy.RequireClaim("isUser").RequireClaim("isAdmin")); 
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BudgetApp", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference  = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });
        }
    }
}
