using System.Data;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SharedKernel.Application.Interfaces;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace SharedKernel.Infrastructure.Services
{

    public partial class UnitOfWork<TDbContext, TUnitOfWork> : IUnitOfWork<TDbContext, TUnitOfWork>
        where TDbContext : DbContext
        where TUnitOfWork : class
    {
#pragma warning disable CS0105 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference argument.
#pragma warning disable CS8618 // Possible null reference argument.
        public ILogger<UnitOfWork<TDbContext, TUnitOfWork>> _logger;
        //private ILogger _logger;
        private TUnitOfWork _customUnitOfWork;
        private ILogService _logService;
        private ICacheService _cacheService;
        private IServiceCollection _services;
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private Assembly _assembly;
        private TDbContext context;
        public IHttpContextAccessor _httpContextAccessor;
        public IUnitOfWork<TDbContext, TUnitOfWork> unitOfWork;
        public virtual ILocalizationService LocalizationService { get; set; }
        public UnitOfWork(TDbContext context, ILogger<UnitOfWork<TDbContext, TUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly, TUnitOfWork customUnitOfWork)
        {
            _services = services;
            _logger = logger;
            _customUnitOfWork = customUnitOfWork;
            _assembly = programAssembly;
            _logService = logService;
            _cacheService = cacheService;
            _services = services;
            this.context = context;
            _cultureInfo = new CultureInfo("en-US");
            unitOfWork = this;
            _resourceManager = new ResourceManager("SharedKernel.Resources." + _cultureInfo.Name, _assembly);
            _httpContextAccessor = new HttpContextAccessor();
            LocalizationService = new LocalizationService("SharedKernel.Resources.en-US", _assembly, "en-US");
            Initialize(context, logger, logService, cacheService, services, programAssembly);
        }
        public UnitOfWork(TDbContext context, ILogger<UnitOfWork<TDbContext, TUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly)
        {
            _services = services;
            _logger = logger;
            _assembly = programAssembly;
            _logService = logService;
            _cacheService = cacheService;
            _services = services;
            this.context = context;
            _cultureInfo = new CultureInfo("en-US");
            unitOfWork = this;
            _resourceManager = new ResourceManager("SharedKernel.Resources." + _cultureInfo.Name, _assembly);
            _httpContextAccessor = new HttpContextAccessor();
            LocalizationService = new LocalizationService("SharedKernel.Resources.en-US", _assembly, "en-US");
            Initialize(context, logger, logService, cacheService, services, programAssembly);
        }

        public UnitOfWork(TDbContext dbContext)
        {

            this.context = dbContext;
            _cultureInfo = new CultureInfo("en-US");
            unitOfWork = this;
            _assembly = Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedKernel.Resources." + _cultureInfo.Name, _assembly);
            _httpContextAccessor = new HttpContextAccessor();
            LocalizationService = new LocalizationService("SharedKernel.Resources.en-US", _assembly, "en-US");
            _services = new ServiceCollection();
            _services.AddMemoryCache();
            _services.AddSingleton<Serilog.ILogger>(_ => Serilog.Log.Logger);
            _services.AddSingleton<ILogService, LogService>();
            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day, buffered: false)
               .WriteTo.Logger(lc => lc
                   .Filter.ByExcluding(e => e.Properties.ContainsKey("RequestPath") || e.Properties.ContainsKey("RequestBody") || e.Properties.ContainsKey("ResponseBody"))
                   .WriteTo.File(GetLogFilePath("log.txt"), restrictedToMinimumLevel: LogEventLevel.Information))
               .WriteTo.File(GetLogFilePath("querylog.txt"), restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day, buffered: false)
               .CreateLogger();
            //var hostProvider = Host.CreateApplicationBuilder();
            ////Host.UseSerilog((hostingContext, loggerConfiguration) =>
            ////{
            ////    loggerConfiguration
            ////        .ReadFrom.Configuration(hostingContext.Configuration)
            ////        .WriteTo.Console();
            ////});

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
            //_logService = _services.BuildServiceProvider().GetRequiredService<ILogService>() ?? null;
            _logger = serviceProvider.GetRequiredService<ILogger<UnitOfWork<TDbContext, TUnitOfWork>>>();
            _cacheService = serviceProvider.GetRequiredService<ICacheService>();
            context = dbContext;
            _services.AddSingleton<IConfiguration>(configuration);
            Initialize(context, _logger, _cacheService, _services);
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
        private void Initialize(TDbContext context, ILogger<UnitOfWork<TDbContext, TUnitOfWork>> logger, ICacheService cacheService, IServiceCollection services)
        {
            this.context = context;
            this._logger = logger;
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
            return LocalizationService.SetCulture(culture);
        }
        public virtual string GetLocalizedString(string key)
        {
            _cultureInfo = _cultureInfo ?? new CultureInfo("en-US");
            _assembly = _assembly ?? Assembly.GetExecutingAssembly();
            _resourceManager = _resourceManager ?? new ResourceManager("SharedKernel.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public virtual string GetLocalizedStringWithCulture(string key, CultureInfo culture)
        {
            _cultureInfo = culture;
            _assembly = _assembly ?? Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("SharedKernel.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public virtual TDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            //return new GenericRepository<T, TDbContext, TUnitOfWork>(_customUnitOfWork, ApplicationDbContext);
            return new GenericRepository<T, TDbContext>( ApplicationDbContext);
        }
        //public virtual ILogger Logger
        //{
        //    get { return this._logger; }
        //    set { this._logger = value; }
        //}
        public virtual ILogger Logger
        {
            get { return this._logger; }
            set { this._logger = (ILogger<UnitOfWork<TDbContext, TUnitOfWork>>)value; }
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
                service = new LocalizationService("SharedKernel.Resources.en-US", Assembly.GetExecutingAssembly(), "en-US");
            }
            return LocalizationService = service;
        }
        public virtual ILogService SetLogService(ILogService service)
        {
            return LogService = _logService = service;
        }

        public TUnitOfWork SetCustomUnitOfWork(TUnitOfWork customUnitOfWork)
        {
            _customUnitOfWork = customUnitOfWork;
            return ((IUnitOfWork<TDbContext, TUnitOfWork>)this).UnitOfWork.SetCustomUnitOfWork(customUnitOfWork);
        }
    }
}
