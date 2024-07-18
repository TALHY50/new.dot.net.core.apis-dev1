using App.Application.Ports.Services;
using App.Infrastructure.Persistence.Services.ConfirmTransactionService;
using App.Infrastructure.Persistence.Services.Quotation;
using App.Infrastructure.Persistence.Services.SendMoney;
using App.Infrastructure.Persistence.Services.Transaction;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PayAll.Exception;
using SharedKernel.Infrastructure.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Payall and Thunes API"

    });
});

Env.NoClobber().TraversePath().Load();

var server = Env.GetString("DB_HOST");
var database = Env.GetString("DB_DATABASE");
var userName = Env.GetString("DB_USERNAME");
var password = Env.GetString("DB_PASSWORD");
var port = Env.GetString("DB_PORT");

var connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString, options =>
    {
        options.EnableRetryOnFailure();
    }));
//builder.Services.AddScoped<IImtCurrencyRepository, ImtCurrencyRepository>();
//builder.Services.AddScoped<IImtCountryRepository, ImtCountryRepository>();

builder.Services.AddTransient<IImtConfirmTransactionService, ImtConfirmTransactionService>();
builder.Services.AddTransient<IImtQuotationService, ImtQuotationService>();
builder.Services.AddTransient<IImtMoneyTransferService, ImtMoneyTransferService>();
builder.Services.AddTransient<IImtSendMoneyService, ImtSendMoneyService>();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Payall and Thunes API v1");
});
//}


app.UseAuthorization();

app.MapControllers();


app.Run();

namespace App
{
}