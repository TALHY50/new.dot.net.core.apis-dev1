using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using ACL.Database;
using ACL.Services;
using ACL.Services.Interface;
using DotNetEnv;
using ACL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Serilog.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


Env.NoClobber().TraversePath().Load();

var server = Env.GetString("DB_HOST");
var database = Env.GetString("DB_DATABASE");
var userName = Env.GetString("DB_USERNAME");
var password = Env.GetString("DB_PASSWORD");

var connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options =>
    {
        options.EnableRetryOnFailure();
    }));
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddMemoryCache();
IConfiguration configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Error) // Log exceptions to log.txt
    .WriteTo.File(GetLogFilePath("querylog.txt"), restrictedToMinimumLevel: LogEventLevel.Information) // Log queries to query.txt
    .CreateLogger();

static string GetLogFilePath(string fileName)
{
    var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    Directory.CreateDirectory(logDirectory); // Ensure the directory exists
    var datePrefix = DateTime.Now.ToString("yyyy-MM-dd");
    return Path.Combine(logDirectory, $"{datePrefix}_{fileName}");
}


builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use Serilog request logging middleware
app.UseSerilogRequestLogging();

// Enable CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseFileServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.Run();
