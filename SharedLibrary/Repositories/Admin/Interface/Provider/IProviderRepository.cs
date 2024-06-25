using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;
using SharedLibrary.Models.Admin.Provider;

namespace SharedLibrary.Repositories.Admin.Interface.Provider
{
    public interface IProviderRepository : IGenericRepository<AdminProvider>
    {
    }
}