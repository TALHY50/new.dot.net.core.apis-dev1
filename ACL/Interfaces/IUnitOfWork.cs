
using System.Data;
using ACL.Database;
using ACL.Interfaces.Repositories;
using ACL.Interfaces.Repositories.V1;

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


        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public IAclPageRepository AclPageRepository { get; }

        IUnitOfWork GetService();
        public IDbTransaction BeginTransaction();
        Task CompleteAsync();

        public void Complete();




    }
}
