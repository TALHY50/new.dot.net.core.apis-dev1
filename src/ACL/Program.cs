
using System.Configuration;
using System.Security.Cryptography;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Application.UseCases.CreateUser;
using ACL.Application.UseCases.Login;
using ACL.Application.UseCases.RefreshToken;
using ACL.Application.UseCases.SignOut;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using ACL.Database;
using ACL.Services;
using DotNetEnv;
using ACL.Interfaces;
using Microsoft.AspNetCore.Authentication;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Data;
using ACL.Infrastructure.Authorization;
using ACL.Infrastructure.Services;
using ACL.Infrastructure.Services.Cryptography;
using ACL.Infrastructure.Services.Jwt;
using ACL.Interfaces.Repositories.V1;
using ACL.Repositories.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SharedLibrary.CustomMiddleWare;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using AuthenticationService = Microsoft.AspNetCore.Authentication.AuthenticationService;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(loggingBuilder =>
{
    // Add console logger
    loggingBuilder.AddConsole();
    loggingBuilder.AddSerilog(dispose: true);
});

var jwtSettingsConfiguration = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsConfiguration);
var jwtSettings = jwtSettingsConfiguration.Get<JwtSettings>();

builder.Services.AddSingleton<IAuthTokenService, JwtService>();
builder.Services.AddSingleton<ICryptographyService, CryptographyService>();

builder.Services.AddSingleton(provider =>
{
    var rsa = RSA.Create();
    rsa.ImportRSAPrivateKey(source: Convert.FromBase64String(jwtSettings.AccessTokenSettings.PrivateKey), bytesRead: out int _);
    return new RsaSecurityKey(rsa);
});

RSA rsa = RSA.Create();
rsa.ImportRSAPublicKey(
    source: Convert.FromBase64String(jwtSettings.AccessTokenSettings.PublicKey),
    bytesRead: out int _
);

var rsaKey = new RsaSecurityKey(rsa);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        if (builder.Environment.IsDevelopment()) options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.AccessTokenSettings.Issuer,
            ValidAudience = jwtSettings.AccessTokenSettings.Audience,
            IssuerSigningKey = rsaKey,
            ClockSkew = TimeSpan.FromMinutes(0)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanReadWeather", policy =>
        policy.Requirements.Add(new GetWeatherRequirement()));
});

// Singletons
builder.Services.AddSingleton<IAuthorizationHandler, GetWeatherHandler>();

//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization(); // Add authorization services
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

builder.Services.AddScoped<IAclUserRepository, AclUserRepository>();

builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<RefreshTokenUseCase>();
builder.Services.AddScoped<SignOutUseCase>();
builder.Services.AddScoped<CreateUserUseCase>();

static string GetLogFilePath(string fileName)
{
    var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    Directory.CreateDirectory(logDirectory);
    var datePrefix = DateTime.Now.ToString("yyyy-MM-dd");
    return Path.Combine(logDirectory, $"{datePrefix}_{fileName}");
}
var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

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



app.UseRouting();





app.UseFileServer();

app.UseHttpsRedirection();


app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.Run();