
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using ACL.Database;
using ACL.Services;
using DotNetEnv;
using ACL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using ACL.Services.CustomMiddleWare;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Exceptions;
using ACL.Data;
using SharedLibrary.CustomMiddleWare;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder =>
{
    // Add console logger
    loggingBuilder.AddConsole();
    loggingBuilder.AddSerilog(dispose: true);
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(); // Add authorization services
builder.Services.AddControllers();

Env.NoClobber().TraversePath().Load();

var server = Env.GetString("DB_HOST");
var database = Env.GetString("DB_DATABASE");
var userName = Env.GetString("DB_USERNAME");
var password = Env.GetString("DB_PASSWORD");
var port = Env.GetString("DB_PORT");

var connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySQL(connectionString, options =>
//    {
//        options.EnableRetryOnFailure();
//    }));

#if UNIT_TEST
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("acl").ConfigureWarnings(warnings =>
    {
        warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning);
    }));
#else
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString, options =>
    {
        options.EnableRetryOnFailure();
    }));
#endif
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddMemoryCache();
IConfiguration configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();
builder.Services.AddScoped<ICustomUnitOfWork, CustomUnitOfWork>();
builder.Services.AddScoped<IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork>, UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>>();
builder.Services.AddSingleton(configuration);
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddSerilog(dispose: true);
});

builder.Services.AddSingleton<Serilog.ILogger>(_ => Log.Logger);
builder.Services.AddSingleton<ILocalizationService>(new LocalizationService("ACL.Resources.en-US", typeof(Program).Assembly, "en-US"));
builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(_ => (Microsoft.Extensions.Logging.ILogger)Log.Logger);
builder.Services.AddScoped<ILogService, LogService>();

Log.Logger = new LoggerConfiguration()
   .MinimumLevel.Debug()
   .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day, buffered: false)
   .WriteTo.Logger(lc => lc
       .Filter.ByExcluding(e => e.Properties.ContainsKey("RequestPath") || e.Properties.ContainsKey("RequestBody") || e.Properties.ContainsKey("ResponseBody"))
       .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Information))
   .WriteTo.File(GetLogFilePath("querylog.txt"), restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day, buffered: false)
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
var app = builder.Build();

// Seeding Data
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();

    // Ensure the database is created
    dbContext.Database.EnsureCreated();

    // Perform the seeding
    SeedData.Initialize(services);
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

//app.UseGlobalExceptionHandler();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseSerilogRequestLogging();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

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