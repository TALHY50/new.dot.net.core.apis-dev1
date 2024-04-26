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
using Microsoft.Extensions.Logging;
using ACL.Database.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Globalization;
using System.Resources;
using System.Reflection;
using Serilog.Core;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Services
{
    public class CustomUnitOfWork :UnitOfWork<ApplicationDbContext>, ICustomUnitOfWork
    {
        private ApplicationDbContext context;
        private Assembly _assembly;
        IUnitOfWork<ApplicationDbContext> _baseunitOfWork;
        ICustomUnitOfWork _unitOfWork;
 public CustomUnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork<ApplicationDbContext>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly)
            : base(context, logger, logService, cacheService, services, programAssembly)
        {
        }
        public CustomUnitOfWork(ApplicationDbContext context):base(context)
        {
            
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
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

        public ICustomUnitOfWork GetService()
        {
            return this;
        }

        public IAclPageRepository AclPageRepository
        {
            get { return new AclPageRepository(this); }
        }
        
        public IAclPageRouteRepository AclPageRouteRepository
        {
            get { return new AclPageRouteRepository(this); }
        }

        public IAclUserRepository AclUserRepository
        {
            get { return new AclUserRepository(this, Config); }
        }
        
        public IAclUserUserGroupRepository AclUserUserGroupRepository
        {
            get { return new AclUserUserGroupRepository(this); }
        }

        public IAclUserGroupRepository AclUserGroupRepository
        {
            get { return new AclUserGroupRepository(this); }
        }

        public IAclPasswordRepository AclPasswordRepository
        {
            get { return new AclPasswordRepository(this); }
        } 
        
        public IAclStateRepository AclStateRepository
        {
            get { return new AclStateRepository(this); }
        }

        ICustomUnitOfWork ICustomUnitOfWork._unitOfWork => new CustomUnitOfWork(ApplicationDbContext);

        IGenericRepository<T> IUnitOfWork<ApplicationDbContext>.GenericRepository<T>()
        {
            return GenericRepository<T>();
        }

        IUnitOfWork<ApplicationDbContext> IUnitOfWork<ApplicationDbContext>.GetService()
        {
            return this;
        }
    }
}