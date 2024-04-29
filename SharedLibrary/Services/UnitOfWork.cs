using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Microsoft.Extensions.Hosting;

namespace SharedLibrary.Services
{

    public class UnitOfWork<TDbContext, TUnitOfWork> : IUnitOfWork<TDbContext, TUnitOfWork>
        where TDbContext : DbContext
        where TUnitOfWork : class
    {
        private ILogger _logger;
        private TUnitOfWork _customUnitOfWork;
        private ILogService _logService;
        private ICacheService _cacheService;
        private IServiceCollection _services;
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private Assembly _assembly;
        private TDbContext context;
        private IHttpContextAccessor _httpContextAccessor;
        public IUnitOfWork<TDbContext, TUnitOfWork> unitOfWork;
        public ILocalizationService LocalizationService { get; private set; }
        public UnitOfWork(TDbContext context, ILogger<UnitOfWork<TDbContext, TUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly)
        {
            _services = services;
            Initialize(context, logger, logService, cacheService, services, programAssembly);
        }

        public UnitOfWork(TDbContext dbContext)
        {
            _services = new ServiceCollection();
            _services.AddMemoryCache();
            _services.AddSingleton<Serilog.ILogger>(_ => Serilog.Log.Logger);
            _services.AddScoped<ILogService, LogService>();
            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day, buffered: false)
               .WriteTo.Logger(lc => lc
                   .Filter.ByExcluding(e => e.Properties.ContainsKey("RequestPath") || e.Properties.ContainsKey("RequestBody") || e.Properties.ContainsKey("ResponseBody"))
                   .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Information))
               .WriteTo.File(GetLogFilePath("querylog.txt"), restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day, buffered: false)
               .CreateLogger();
            var hostProvider = Host.CreateApplicationBuilder();
            //Host.UseSerilog((hostingContext, loggerConfiguration) =>
            //{
            //    loggerConfiguration
            //        .ReadFrom.Configuration(hostingContext.Configuration)
            //        .WriteTo.Console();
            //});

            //services.AddSerilog();
            _services.AddSingleton<ICacheService, CacheService>();
            _services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddSerilog(dispose: true);
                });
            _services.AddLogging();
            IConfiguration configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();
            var serviceProvider = _services.BuildServiceProvider();
#pragma warning disable CS8601 // Possible null reference assignment.
            //  _logService = serviceProvider.GetRequiredService<ILogService>() ?? null;
#pragma warning restore CS8601 // Possible null reference assignment.
            var logger = serviceProvider.GetRequiredService<ILogger<UnitOfWork<TDbContext, TUnitOfWork>>>();
            var cacheService = serviceProvider.GetRequiredService<ICacheService>();
            context = dbContext;
            _services.AddSingleton<IConfiguration>(configuration);
            Initialize(context, logger, null, cacheService, _services);
        }
        static string GetLogFilePath(string fileName)
        {
            var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDirectory);
            var datePrefix = DateTime.Now.ToString("yyyy-MM-dd");
            return Path.Combine(logDirectory, $"{datePrefix}_{fileName}");
        }
        private void Initialize(TDbContext context, ILogger<UnitOfWork<TDbContext, TUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services)
        {
            this.context = context;
            this._logger = logger;
            this._logService = logService;
            this._cacheService = cacheService;
            this._services = services;

        }
        private void Initialize(TDbContext context, ILogger<UnitOfWork<TDbContext, TUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly assembly)
        {
            this.context = context;
            this._logger = logger;
            this._logService = logService;
            this._cacheService = cacheService;
            this._services = services;
            _assembly = assembly;
        }
        public virtual CultureInfo SetCulture(string culture)
        {
            // LocalizationService?? new Loca
            return LocalizationService.SetCulture(culture);
        }
        public virtual string GetLocalizedString(string key)
        {
            _cultureInfo = _cultureInfo ?? new CultureInfo("en-US");
            _assembly = _assembly ?? Assembly.GetExecutingAssembly();
            _resourceManager = _resourceManager ?? new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public virtual string GetLocalizedStringWithCulture(string key, CultureInfo culture)
        {
            _cultureInfo = culture;
            _assembly = _assembly ?? Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedLibrary.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public virtual TDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T, TDbContext, TUnitOfWork>(_customUnitOfWork, ApplicationDbContext);
        }
        public virtual ILogger Logger
        {
            get { return this._logger; }
            set { this._logger = value; }
        }


        public virtual ILogService LogService
        {
            get { return this._logService; }
            set { this._logService = value; }
        }

        public virtual ICacheService CacheService
        {
            get
            { return this._cacheService; }
            set { this._cacheService = value; }
        }

        public virtual IConfiguration Config
        {
            get
            {
                return new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            }

        }

        public IHttpContextAccessor HttpContextAccessor
        {
            get { return this._httpContextAccessor; }
            set { this._httpContextAccessor = value; }
        }

        Microsoft.Extensions.Logging.ILogger IUnitOfWork<TDbContext, TUnitOfWork>.Logger { get => this.Logger; set => this.Logger = value; }

        IUnitOfWork<TDbContext, TUnitOfWork> IUnitOfWork<TDbContext, TUnitOfWork>.UnitOfWork { get => this; set => this.unitOfWork = value; }

        public async Task CompleteAsync()
        {
            await this.ApplicationDbContext.SaveChangesAsync();
        }

        public void Complete()
        {
            ApplicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.ApplicationDbContext.Dispose();
        }

        public IUnitOfWork<TDbContext, TUnitOfWork> GetService()
        {
            return this;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await ApplicationDbContext.Database.BeginTransactionAsync();
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = ApplicationDbContext.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            await this.ApplicationDbContext.Database.CommitTransactionAsync();
        }

        public void CommitTransaction()
        {
            this.ApplicationDbContext.Database.CommitTransaction();
        }

        public async Task RollbackTransactionAsync()
        {
            await this.ApplicationDbContext.Database.RollbackTransactionAsync();
        }
        public void RollbackTransaction()
        {
            this.ApplicationDbContext.Database.RollbackTransaction();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return ApplicationDbContext.Database.CreateExecutionStrategy();
        }
        public virtual Assembly SetAssembly(Assembly assembly)
        {
            if (LocalizationService == null)
            {
                LocalizationService = new LocalizationService("ACL.Resources.en-US", assembly, "en-US");
            }
            return LocalizationService.SetAssembly(assembly);
        }
        public virtual ResourceManager SetReourceManager(CultureInfo resource, Assembly assembly)
        {
            if (LocalizationService == null)
            {
                LocalizationService = new LocalizationService("ACL.Resources.en-US", _assembly, "en-US");
            }
            //assembly ??= Assembly.GetEntryAssembly();
            assembly = Assembly.GetExecutingAssembly();
            return LocalizationService.SetReourceManager(resource, _assembly ?? assembly);
        }

        IUnitOfWork<TDbContext, TUnitOfWork> IUnitOfWork<TDbContext, TUnitOfWork>.GetService()
        {
            return this;
        }
        public virtual ILocalizationService SetLocalizationService(ILocalizationService service)
        {
            if (service == null)
            {
                service = new LocalizationService("SharedLibrary.Resources.en-US", Assembly.GetExecutingAssembly(), "en-US");
            }
            return LocalizationService = service;
        }
    }
}
