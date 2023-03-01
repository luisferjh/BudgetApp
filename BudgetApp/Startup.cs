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

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();          
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();          
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<SecurityTools>();
            services.AddTransient<IMapping, AutoMapperImplementation>();

            // initialize static service provider
            StaticServiceProvider.BuildProvider(services);
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
