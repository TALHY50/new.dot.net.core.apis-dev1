using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN.Core.Entities.Provider;
using SharedLibrary.Interfaces;

namespace ADMIN.Application.Ports.Repositories.Provider
{
    public interface IProviderRepository:IGenericRepository<AdminProvider>
    {
    }
}
