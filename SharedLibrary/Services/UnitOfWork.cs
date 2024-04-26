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

namespace SharedLibrary.Services
{

    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private ILogger _logger;
        private ILogService _logService;
        private ICacheService _cacheService;
        private IServiceCollection _services;
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private Assembly _assembly;
        private TDbContext context;
        private IHttpContextAccessor _httpContextAccessor;
        public ILocalizationService LocalizationService { get; private set; }
        public UnitOfWork(TDbContext context, ILogger<UnitOfWork<TDbContext>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly)
        {
            Initialize(context, logger, logService, cacheService, services);
        }

        public UnitOfWork(TDbContext dbContext)
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<ICacheService, CacheService>();
            services.AddLogging();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<UnitOfWork<TDbContext>>>();
            var logService = serviceProvider.GetRequiredService<ILogService>();
            var cacheService = serviceProvider.GetRequiredService<ICacheService>();
            context = dbContext;
            Initialize(context, logger, logService, cacheService, services);
            //Initialize(context, null, null, null, services);
        }


        private void Initialize(TDbContext context, ILogger<UnitOfWork<TDbContext>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services)
        {
            this.context = context;
            this._logger = logger;
            this._logService = logService;
            this._cacheService = cacheService;
            this._services = services;

        }
        public CultureInfo SetCulture(string culture)
        {
            return LocalizationService.SetCulture(culture);
        }
        public string GetLocalizedString(string key)
        {
            _cultureInfo = _cultureInfo ?? new CultureInfo("en-US");
            _assembly = _assembly ?? Assembly.GetExecutingAssembly();
            _resourceManager = _resourceManager ?? new ResourceManager("ACL.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public string GetLocalizedStringWithCulture(string key, CultureInfo culture)
        {
            _cultureInfo = culture;
            _assembly = _assembly ?? Assembly.GetExecutingAssembly();
            _resourceManager = new ResourceManager("ACL.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public TDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T,TDbContext>(this);
        }
        public ILogger Logger
        {
            get { return this._logger; }
            set { this._logger = value; }
        }


        public ILogService LogService
        {
            get { return this._logService; }
            set { this._logService = value; }
        }

        public ICacheService CacheService
        {
            get
            { return this._cacheService; }
            set { this._cacheService = value; }
        }

        public IConfiguration Config
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

        public IUnitOfWork<TDbContext> GetService()
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
        public Assembly SetAssembly(Assembly assembly)
        {
            return LocalizationService.SetAssembly(assembly);
        }
        public ResourceManager SetReourceManager(CultureInfo resource, Assembly assembly)
        {
            assembly ??= Assembly.GetEntryAssembly();
            return LocalizationService.SetReourceManager(resource, _assembly ?? assembly);
        }
    }
}
