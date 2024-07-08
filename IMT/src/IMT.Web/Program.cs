
using IMT.PayAll.Exception;
using DotNetEnv;
using Microsoft.OpenApi.Models;
using SharedLibrary.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Infrastructure.Persistence.Services.QuotationService;
using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using IMT.Application.Infrastructure.Persistence.Repositories.ImtCountry;
using IMT.Application.Infrastructure.Persistence.Repositories.ImtCurrency;
using IMT.Application.Domain.Ports.Services.Transaction;
using IMT.Application.Infrastructure.Persistence.Services.Transaction;
using IMT.Application.Domain.Ports.Services.SendMoney;
using IMT.Application.Infrastructure.Persistence.Services.SendMoney;


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
builder.Services.AddScoped<IImtQuotationService, ImtQuotationService>();
builder.Services.AddScoped<IImtMoneyTransferService, ImtMoneyTransferService>();
builder.Services.AddScoped<IImtSendMoneyService, ImtSendMoneyService>();
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
