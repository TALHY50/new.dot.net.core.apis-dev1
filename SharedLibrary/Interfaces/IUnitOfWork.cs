using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces
{
    public interface IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        TDbContext ApplicationDbContext { get; set; }
        ILogger Logger { get; set; }
        IHttpContextAccessor HttpContextAccessor { get; }
        IGenericRepository<T> GenericRepository<T>() where T : class;
        ILogService LogService { get; set; }
        ILocalizationService LocalizationService { get; }
        IConfiguration Config { get; }
        IUnitOfWork<TDbContext> GetService();
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
