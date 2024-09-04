using Mapster;
using Microsoft.AspNetCore.HttpOverrides;
using Wallet.Firebase.Api.Models.Settings;
using Wallet.Firebase.Api.Repositories;
using Wallet.Firebase.Api.Repositories.Interfaces;
using Wallet.Firebase.Api.Services;
using Wallet.Firebase.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
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

app.Run();

