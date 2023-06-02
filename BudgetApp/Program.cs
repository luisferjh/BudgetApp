using Budget.Application.Interfaces;
using BudgetApp;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

//var serviceLogger = (ILogService)app.Services.GetService(typeof(ILogService));
//startup.Configure(app, app.Environment, serviceLogger);
startup.Configure(app, app.Environment, app.Services);

app.Run();
