using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN.Application.Ports.Repositories.Interface;
using ADMIN.Infrastructure.Persistence.Configurations;
using SharedLibrary.Interfaces;

namespace ADMIN.Infrastructure.Persistence.UnitOfWork.Interface
{
    public interface ICustomUnitOfWork : IDisposable, IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>
    {
        ICustomUnitOfWork _unitOfWork { get; }
        IUnitOfWork<ApplicationDbContext,CustomUnitOfWork> _baseUnitOfWork { get; }
        IProviderRepository ProviderRepository { get; }
    }
}
