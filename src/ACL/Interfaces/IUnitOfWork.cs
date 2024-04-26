using ACL.Services;
using System.Data;
using ACL.Database;
using ACL.Interfaces.Repositories.V1;
using Microsoft.EntityFrameworkCore.Storage;
using ACL.Interfaces.Repositories;
using ACL.Controllers.V1;
using ACL.Services.Interface;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Globalization;
using System.Reflection;
using System.Resources;


namespace ACL.Interfaces
{
    public interface IUnitOfWork
    {

        ApplicationDbContext ApplicationDbContext { get; set; }
        ILogger Logger { get; set; }
        IGenericRepository<T> GenericRepository<T>() where T : class;
        ILogService LogService { get; set; }
        ILocalizationService LocalizationService { get; }
        IAclCompanyRepository AclCompanyRepository { get; }
        IConfiguration Config { get; }
        IAclCompanyModuleRepository AclCompanyModuleRepository { get; }
        IAclModuleRepository AclModuleRepository { get; }
        IAclSubModuleRepository AclSubModuleRepository { get; }
        IAclRoleRepository AclRoleRepository { get; }
        IAclUserGroupRoleRepository AclUserGroupRoleRepository { get; }
        IAclRolePageRepository AclRolePageRepository { get; }

       // IHttpContextAccessor HttpContextAccessor { get; set; }

        IAclPageRepository AclPageRepository { get; }
        IAclUserRepository AclUserRepository { get; }
        IAclPasswordRepository AclPasswordRepository { get; }
        IAclUserGroupRepository AclUserGroupRepository { get; }

        IUnitOfWork GetService();
        IDbTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CompleteAsync();
        public void Complete();
        void RollbackTransaction();
        Task RollbackTransactionAsync();
        Task CommitTransactionAsync();
        void CommitTransaction();
        IExecutionStrategy CreateExecutionStrategy();
        string GetLocalizedString(string key);
        string GetLocalizedStringWithCulture(string key, CultureInfo culture);
        CultureInfo SetCulture(string culture);
        ResourceManager SetReourceManager(CultureInfo resource, Assembly assembly);
        Assembly SetAssembly(Assembly assembly);
       
    }
}