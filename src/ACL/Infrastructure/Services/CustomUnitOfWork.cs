﻿using System.Globalization;
using System.Reflection;
using System.Resources;
using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Application.Interfaces.ServiceInterfaces;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.V1;
using ACL.Infrastructure.Services.Cryptography;
using Microsoft.Extensions.Caching.Distributed;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Services
{
    public class CustomUnitOfWork : UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>, ICustomUnitOfWork
    {
        private ApplicationDbContext context;
        private Assembly _assembly;
        private ILogService _logService;
        IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork> _baseunitOfWork;
        ICustomUnitOfWork _unitOfWork;
        readonly IDistributedCache _distributedCache;
        public CustomUnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly)
                   : base(context, logger, logService, cacheService, services, programAssembly)
        {
            this._assembly = programAssembly;
            this.context = context;
            this._logService = logService;
            this._baseunitOfWork = base.unitOfWork;
            this._unitOfWork = this;
            base.SetLogService(logService);
            this._assembly = programAssembly;
            this._unitOfWork.SetAssembly(this._assembly);
        }
         public CustomUnitOfWork(ApplicationDbContext context,IDistributedCache distributedCache) : base(context)
        {
            this.context = context;
            this._unitOfWork = this;
            this._baseunitOfWork = base.unitOfWork;
            base.SetLogService(this._logService);
            this._distributedCache = distributedCache;
            this._assembly = Assembly.GetExecutingAssembly() ?? Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
            this._unitOfWork.SetAssembly(this._assembly);
            this._unitOfWork.SetLocalizationService(new LocalizationService("ACL.Resources.en-US", typeof(Program).Assembly, "en-US"));
        }
        public CustomUnitOfWork(ApplicationDbContext context) : base(context)
        {
            this.context = context;
            this._unitOfWork = this;
            this._baseunitOfWork = base.unitOfWork;
            base.SetLogService(this._logService);
            this._assembly = Assembly.GetExecutingAssembly() ?? Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
            this._unitOfWork.SetAssembly(this._assembly);
            this._unitOfWork.SetLocalizationService(new LocalizationService("ACL.Resources.en-US", typeof(Program).Assembly, "en-US"));
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
        public ICryptographyService cryptographyService
        {
            get { return new CryptographyService(this); }
        }
        public IAclCompanyRepository AclCompanyRepository
        {
            get { return new AclCompanyRepository(this._unitOfWork, Config); }
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
            get { return new AclRoleRepository(this,this._distributedCache); }

        }

        public IAclUserGroupRoleRepository AclUserGroupRoleRepository
        {
            get { return new AclUserGroupRoleRepository(this); }
        }

        public override ResourceManager SetReourceManager(CultureInfo resource = null, Assembly assembly = null)
        {
            resource ??= new CultureInfo("en-US");
            assembly ??= this._assembly;
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
            get { return new AclUserRepository(this, Config,this.ApplicationDbContext,this._distributedCache); }
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

        IUnitOfWork<ApplicationDbContext, CustomUnitOfWork> IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>.UnitOfWork { get { return this._unitOfWork; } set => this.unitOfWork = (IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork>)this._unitOfWork; }

        IUnitOfWork<ApplicationDbContext, CustomUnitOfWork> ICustomUnitOfWork._baseUnitOfWork => this._unitOfWork;

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