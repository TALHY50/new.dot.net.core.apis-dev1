using ACL.Controllers.V1;
using ACL.Database;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using ACL.Interfaces.Repositories.V1;
using ACL.Repositories;
using ACL.Repositories.V1;
using Microsoft.EntityFrameworkCore.Storage;
using ACL.Services;
using System.Data;
using ACL.Services.Interface;
using Microsoft.Extensions.Logging;
using ACL.Database.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Globalization;
using System.Resources;
using System.Reflection;
using Serilog.Core;

namespace ACL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private ILogger _logger;
        private ILogService _logService;
        private ICacheService _cacheService;
        private IServiceCollection _services;
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private Assembly _assembly;
        public ILocalizationService LocalizationService { get; private set; }
        public UnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork> logger, ILogService logService, ICacheService cacheService, IServiceCollection services)
        {
            Initialize(context, logger, logService, cacheService, services);
        }

        // Constructor with only ApplicationDbContext
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            services.AddSingleton<ILogService, LogService>(); // Register LogService as singleton
            services.AddSingleton<ICacheService, CacheService>(); // Register CacheService as singleton
            services.AddLogging(); // Register logging services
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<UnitOfWork>>();
            var logService = serviceProvider.GetRequiredService<ILogService>();
            var cacheService = serviceProvider.GetRequiredService<ICacheService>();

            Initialize(dbContext, logger, logService, cacheService, services);
        }


        private void Initialize(ApplicationDbContext context, ILogger<UnitOfWork> logger, ILogService logService, ICacheService cacheService, IServiceCollection services)
        {
            this.context = context;
            this._logger = logger;
            this._logService = logService;
            this._cacheService = cacheService;
            this._services = services;

            // Add other initialization logic here
        }
        public CultureInfo SetCulture(string culture)
        {
            return LocalizationService.SetCulture(culture);
        }
        public string GetLocalizedString(string key)
        {
            _cultureInfo = _cultureInfo ?? new CultureInfo("en-US");
            _assembly = _assembly ?? typeof(Program).Assembly;
            _resourceManager = _resourceManager ?? new ResourceManager("ACL.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public string GetLocalizedStringWithCulture(string key, CultureInfo culture)
        {
            _cultureInfo = culture;
            _assembly = _assembly ?? typeof(Program).Assembly;
            _resourceManager = new ResourceManager("ACL.Resources." + _cultureInfo.Name, _assembly);
            return _resourceManager.GetString(key, _cultureInfo);
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(this);
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
        public IAclCompanyModuleRepository AclCompanyModuleRepository
        {
            get { return new AclCompanyModuleRepository(this); }

        }
        public IAclCompanyRepository AclCompanyRepository
        {
            get { return new AclCompanyRepository(this, Config); }

        }

        public IAclRolePageRepository AclRolePageRepository
        {
            get { return new AclRolePageRepository(this); }

        }

        public IAclModuleRepository AclModuleRepository
        {
            get { return new AclModuleRepository(this); }

        }
        public IAclSubModuleRepository AclSubModuleRepository
        {
            get { return new AclSubModuleRepository(this); }

        }
        public IAclRoleRepository AclRoleRepository
        {
            get { return new AclRoleRepository(this); }

        }

        public IAclUserGroupRoleRepository AclUserGroupRoleRepository
        {
            get { return new AclUserGroupRoleRepository(this); }
        }

        //public IHttpContextAccessor HttpContextAccessor
        //{
        //    get { return this._httpContextAccessor; }
        //    set { this._httpContextAccessor = value; }
        //}

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

        public IUnitOfWork GetService()
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

        public IAclPageRepository AclPageRepository
        {
            get { return new AclPageRepository(this); }
        }

        public IAclUserRepository AclUserRepository
        {
            get { return new AclUserRepository(this, Config); }
        }

        public IAclUserGroupRepository AclUserGroupRepository
        {
            get { return new AclUserGroupRepository(this); }
        }

        public IAclPasswordRepository AclPasswordRepository
        {
            get { return new AclPasswordRepository(this); }
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