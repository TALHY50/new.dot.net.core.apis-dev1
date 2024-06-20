using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADMIN.Contracts.Requests;
using ADMIN.Contracts.Response;
using ADMIN.Core.Entities.AdminProvider;
using SharedLibrary.Interfaces;

namespace ADMIN.Application.Ports.Repositories.Interface
{
    public interface IProviderRepository : IGenericRepository<AdminProvider>
    {
        AdminProvider? AddProvider(ProviderRequest request);
        AdminProvider? UpdateProvider(ulong id, ProviderRequest request);
        AdminProvider? DeleteProvider(ulong id);
    }
}