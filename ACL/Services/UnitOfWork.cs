using ACL.Database;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using ACL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Repositories;
using System.Data;

namespace ACL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private ILogger logger;
        private ILogService logService;
        private IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("Logs");
            this._httpContextAccessor = httpContextAccessor;
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }

        public ILogger Logger
        {
            get { return this.logger; }
            set { this.logger = value; }
        }
        public ILogService LogService
        {
            get { return this.logService; }
            set { this.logService = value; }
        }

        public IAclCompanyModuleRepository AclCompanyModuleRepository
        {
            get { return new AclCompanyModuleRepository(this); }

        }
        public IAclSubModuleRepository AclSubModuleRepository
        {
            get { return new AclSubModuleRepository(this); }

        }
        public IAclRoleRepository AclRoleRepository
        {
            get { return new AclRoleRepository(this); }

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

        public async Task BeginTransactionAsync()
        {
            await this.ApplicationDbContext.Database.BeginTransactionAsync();
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

    }
}
