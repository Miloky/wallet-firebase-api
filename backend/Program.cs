using Mapster;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using NLog.Web;
using Wallet.Firebase.Api.Models.Settings;
using Wallet.Firebase.Api.Repositories;
using Wallet.Firebase.Api.Repositories.Interfaces;
using Wallet.Firebase.Api.Services;
using Wallet.Firebase.Api.Services.Interfaces;

var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Info("Starting Application Initialization...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Logging
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Configuration.AddJsonFile("appsettings.local.json", true, true);

    builder.Services.Configure<FirebaseSettings>(builder.Configuration.GetSection("firebase"));
    builder.Services.AddControllers();
    builder.Services.AddMapster();

    // Application
    builder.Services.AddTransient<IAccountService, AccountService>();

    // Domain
    builder.Services.AddTransient<IAccountRepository, AccountRepository>();

    var app = builder.Build();
    
    // TODO: Do we need it?
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });

    app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
    app.UseRouting();
    app.MapDefaultControllerRoute();
    app.MapGet("/", () => "Wallet.Firebase.Api");

    logger.Info("Application Initialized Succesfuly...");

    app.Run();
    
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
