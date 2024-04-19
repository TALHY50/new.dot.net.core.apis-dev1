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
using ACL.Services.CustomMiddleWare;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Localization;
using System.Resources;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Castle.Core.Resource;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("bn-BD")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddTransient<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
builder.Services.AddSingleton<ResourceManager>(sp =>
{
    var baseNameEnUs = "Resources.en-US";
    var baseNameBnBd = "Resources.bn-BD";
    var assembly = typeof(Program).Assembly;
    return new ResourceManager(baseNameBnBd, assembly);
});

builder.Services.AddTransient<IStringLocalizer>(sp =>
{
    var factory = sp.GetRequiredService<IStringLocalizerFactory>();
    var localizer = factory.Create(typeof(Program));
    return localizer;
});
builder.Services.AddTransient<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();

// Add MVC services with specific culture and no suffix
builder.Services.AddMvc()
        .AddViewLocalization(options => options.ResourcesPath = "Resources")
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(FileResource)); // Replace SharedResources with your actual resource type
        });

// Add the ViewLocalization services
builder.Services.AddScoped<IViewLocalizer, ViewLocalizer>();

//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new[]
//    {
//        new CultureInfo("en-US"),
//        new CultureInfo("bn-BD")
//    };

//    options.DefaultRequestCulture = new RequestCulture("en-US");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});
//builder.Services.AddTransient<ResourceManager>(sp =>
//{
//    var baseNameEnUs = "Resources.en-US";
//    var assembly = typeof(Program).Assembly;
//    return new ResourceManager(baseNameEnUs, assembly);
//});

//builder.Services.AddTransient<ResourceManager>(sp =>
//{
//    var baseNameBnBd = "Resources.bn-BD";
//    var assembly = typeof(Program).Assembly;
//    return new ResourceManager(baseNameBnBd, assembly);
//});

//// Uncomment the following line if you want to use ResourceManagerStringLocalizer
////builder.Services.AddTransient<IStringLocalizer, ResourceManagerStringLocalizer>();


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
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Error)
    .WriteTo.Logger(lc => lc
        .Filter.ByExcluding(e => e.Properties.ContainsKey("RequestPath") || e.Properties.ContainsKey("RequestBody") || e.Properties.ContainsKey("ResponseBody"))
        .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Information))
    .WriteTo.File(GetLogFilePath("querylog.txt"), restrictedToMinimumLevel: LogEventLevel.Information)
    .CreateLogger();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .WriteTo.Console();
});

builder.Services.AddSerilog();

static string GetLogFilePath(string fileName)
{
    var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    Directory.CreateDirectory(logDirectory);
    var datePrefix = DateTime.Now.ToString("yyyy-MM-dd");
    return Path.Combine(logDirectory, $"{datePrefix}_{fileName}");
}


builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseRequestLocalization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseSerilogRequestLogging();

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
