//using ACL.Interfaces.Repositories;
using ACL.Interfaces;
using ACL.Services;
using System.Data;
using ACL.Database;

namespace ACL.Interfaces
{
    public interface IUnitOfWork
    {

        public ApplicationDbContext ApplicationDbContext { get; set; }
        public ILogger Logger { get; set; }

        public ILogService LogService { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        IUnitOfWork GetService();
        public IDbTransaction BeginTransaction();
        Task CompleteAsync();

        public void Complete();




    }
}
