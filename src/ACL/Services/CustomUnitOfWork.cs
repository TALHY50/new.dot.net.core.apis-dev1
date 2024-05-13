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
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Runtime.CompilerServices;
using ACL.Interfaces.ServiceInterfaces;
using ACL.Application.Ports.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace ACL.Services
{
    public class CustomUnitOfWork : UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>, ICustomUnitOfWork
    {
        private ApplicationDbContext context;
        private Assembly _assembly;
        private ILogService _logService;
        IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork> _baseunitOfWork;
        ICustomUnitOfWork _unitOfWork;
        private IDistributedCache _distributedCache;
        public CustomUnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly, IDistributedCache distributedCache = null)
                   : base(context, logger, logService, cacheService, services, programAssembly)
        {
            _assembly = programAssembly;
            this.context = context;
            _logService  = logService;
            _baseunitOfWork = base.unitOfWork;
            _unitOfWork = this;
            base.SetLogService(logService);
            _assembly = programAssembly;
            _unitOfWork.SetAssembly(_assembly);
            this._distributedCache = distributedCache;
        }
        public CustomUnitOfWork(ApplicationDbContext context) : base(context)
        {
            this.context = context;
            _unitOfWork = this;
            _baseunitOfWork = base.unitOfWork;
            base.SetLogService(_logService);
            _assembly = Assembly.GetExecutingAssembly() ?? Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
            _unitOfWork.SetAssembly(_assembly);
            _unitOfWork.SetLocalizationService( new LocalizationService("ACL.Resources.en-US", typeof(Program).Assembly, "en-US"));
        }

        public new ApplicationDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }

        public override IConfiguration Config
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
            get { return new AclCompanyRepository(_unitOfWork, Config); }
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

        public override ResourceManager SetReourceManager(CultureInfo resource = null, Assembly assembly = null)
        {
            resource ??= new CultureInfo("en-US");
            assembly ??= _assembly;
            return base.SetReourceManager(resource, assembly);
        }

        public override ILocalizationService SetLocalizationService(ILocalizationService service = null)
        {
            if (service == null)
            {
                service = new LocalizationService("ACL.Resources.en-US", typeof(Program).Assembly, "en-US");
            }
            return base.SetLocalizationService(service);
        }
        public override ILogService LogService { get => base.LogService; set => base.LogService = value; }
        public new ICustomUnitOfWork GetService()
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
            get { return new AclUserRepository(this, Config,this.context, this._distributedCache); }
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
        public IAclCountryRepository AclCountryRepository
        {
            get { return new AclCountryRepository(this); }
        }

        public IAclStateRepository AclStateRepository
        {
            get { return new AclStateRepository(this); }
        }
        public IAclBranchRepository AclBranchRepository
        {
            get { return new AclBranchRepository(this); }
        }
        public IAclBranchService AclBranchService
        {
            get { return new AclBranchService(this); }
        }

        ICustomUnitOfWork ICustomUnitOfWork._unitOfWork => this;

        IUnitOfWork<ApplicationDbContext, CustomUnitOfWork> IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>.UnitOfWork { get { return this._unitOfWork; } set => unitOfWork = (IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork>)this._unitOfWork; }

        IUnitOfWork<ApplicationDbContext, CustomUnitOfWork> ICustomUnitOfWork._baseUnitOfWork =>  this._unitOfWork;

        IUnitOfWork<ApplicationDbContext, CustomUnitOfWork> IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>.GetService()
        {
            return this._unitOfWork;
        }

        CustomUnitOfWork IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>.SetCustomUnitOfWork(CustomUnitOfWork customUnitOfWork)
        {
            base.SetCustomUnitOfWork(this);
            return this;
        }
    }
}