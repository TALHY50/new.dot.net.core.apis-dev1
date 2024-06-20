using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using ADMIN.Application.Ports.Repositories.Interface;
using ADMIN.Infrastructure.Persistence.Configurations;
using ADMIN.Infrastructure.Persistence.Repositories.Provider;
using ADMIN.Infrastructure.Persistence.UnitOfWork.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ADMIN.Infrastructure.Persistence.UnitOfWork
{
    public class CustomUnitOfWork : UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>, ICustomUnitOfWork
    {
        private ApplicationDbContext context;
        private Assembly _assembly;
        private ILogService _logService;
        IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork> _baseunitOfWork;
        ICustomUnitOfWork _unitOfWork;
        public CustomUnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork<ApplicationDbContext, ICustomUnitOfWork>> logger, ILogService logService, ICacheService cacheService, IServiceCollection services, Assembly programAssembly)
            : base(context, logger, logService, cacheService, services, programAssembly)
        {
            _assembly = programAssembly;
            this.context = context;
            _logService = logService;
            _baseunitOfWork = base.unitOfWork;
            _unitOfWork = this;
            base.SetLogService(logService);
            _assembly = programAssembly;
            _unitOfWork.SetAssembly(_assembly);
        }
        public CustomUnitOfWork(ApplicationDbContext context) : base(context)
        {
            this.context = context;
            _unitOfWork = this;
            _baseunitOfWork = base.unitOfWork;
            base.SetLogService(_logService);
            _assembly = Assembly.GetExecutingAssembly() ?? Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
            _unitOfWork.SetAssembly(_assembly);
            _unitOfWork.SetLocalizationService(new LocalizationService("ACL.Resources.en-US", _assembly, "en-US"));
        }

        public new ApplicationDbContext ApplicationDbContext
        {
            get { return this.context; }
            set { this.context = value; }
        }
        public IProviderRepository ProviderRepository
        {
            get { return new ProviderRepository(this); }
        }
        ICustomUnitOfWork ICustomUnitOfWork._unitOfWork => this;

        IUnitOfWork<ApplicationDbContext, CustomUnitOfWork> IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>.UnitOfWork { get { return this._unitOfWork; } set => unitOfWork = (IUnitOfWork<ApplicationDbContext, ICustomUnitOfWork>)this._unitOfWork; }

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
