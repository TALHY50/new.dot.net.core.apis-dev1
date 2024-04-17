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

namespace ACL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private ILogger _logger;
        private ILogService _logService;
        private ICacheService _cacheService;
        private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _config;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor, ICacheService cacheService)
        {
            this.context = context;
            this._logger = loggerFactory.CreateLogger("Logs");
            this._httpContextAccessor = httpContextAccessor;
            this._cacheService = cacheService;
            this._logService = new LogService(this._logger, loggerFactory);
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }

        public ILogger Logger
        {
            get { return this._logger; }
            set { this._logger = value; }
        }
        public IConfiguration Config
        {
            get { return this._config; }
            set { this._config = value; }
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

        public IAclCompanyModuleRepository AclCompanyModuleRepository
        {
            get { return new AclCompanyModuleRepository(this); }

        }
        public IAclCompanyRepository AclCompanyRepository
        {
            get { return new AclCompanyRepository(this,_config); }

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
            get { return new AclUserRepository(this); }
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
    }
}