
using ACL.Services;
using System.Data;
using ACL.Database;
using ACL.Interfaces.Repositories.V1;
using Microsoft.EntityFrameworkCore.Storage;
using ACL.Interfaces.Repositories;
using ACL.Controllers.V1;
using ACL.Services.Interface;


namespace ACL.Interfaces
{
    public interface IUnitOfWork
    {

        public ApplicationDbContext ApplicationDbContext { get; set; }
        public ILogger Logger { get; set; }

        public ILogService LogService { get; set; }

        IAclCompanyModuleRepository AclCompanyModuleRepository { get; }
        IAclModuleRepository AclModuleRepository { get; }
        IAclSubModuleRepository AclSubModuleRepository { get; }
        IAclRoleRepository AclRoleRepository { get; }
        IAclUserGroupRoleRepository AclUserGroupRoleRepository { get; }
        IAclRolePageRepository AclRolePageRepository { get; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public IAclPageRepository AclPageRepository { get; }
        public IAclUserRepository AclUserRepository { get; }
        public IAclUserGroupRepository AclUserGroupRepository { get; }

        IUnitOfWork GetService();
        IDbTransaction BeginTransaction();
        Task<IDbContextTransaction>  BeginTransactionAsync();
        Task CompleteAsync();
        public void Complete();
        void RollbackTransaction();
        Task RollbackTransactionAsync();
        Task CommitTransactionAsync();
        void CommitTransaction();
        IExecutionStrategy CreateExecutionStrategy();
    }
}