using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADMIN.Contracts.Requests;
using ADMIN.Contracts.Response;
using ADMIN.Core.Entities.AdminProvider;
using SharedLibrary.Interfaces;

namespace ADMIN.Application.Ports.Repositories.Interface.Provider
{
    public interface IProviderRepository : IGenericRepository<AdminProvider>
    {
    }
}