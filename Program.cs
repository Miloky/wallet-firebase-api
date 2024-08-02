using Mapster;
using Wallet.Firebase.Api.Repositories;
using Wallet.Firebase.Api.Repositories.Interfaces;
using Wallet.Firebase.Api.Services;
using Wallet.Firebase.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMapster();

// Application
builder.Services.AddTransient<IAccountService, AccountService>();

// Domain
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

var app = builder.Build();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();

