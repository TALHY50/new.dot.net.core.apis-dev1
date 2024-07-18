using System.Data;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SharedKernel.Application.Interfaces
{
    public interface IUnitOfWork<TDbContext,TUnitOfWork> where TDbContext : DbContext where TUnitOfWork : class
    {
        TDbContext ApplicationDbContext { get; set; }
        IUnitOfWork<TDbContext, TUnitOfWork> UnitOfWork { get; set; }
        ILogger Logger { get; set; }
        IHttpContextAccessor HttpContextAccessor { get; }
        IGenericRepository<T> GenericRepository<T>() where T : class;
        ILogService LogService { get; set; }
        ILocalizationService LocalizationService { get; }
        IConfiguration Config { get; }
        IUnitOfWork<TDbContext, TUnitOfWork> GetService();
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
        ILocalizationService SetLocalizationService (ILocalizationService service);
        TUnitOfWork SetCustomUnitOfWork (TUnitOfWork customUnitOfWork);
        ILogService SetLogService(ILogService service);
    }
}
