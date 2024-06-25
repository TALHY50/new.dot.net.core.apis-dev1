using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN.Contracts.Requests;
using ADMIN.Contracts.Response;

using ADMIN.Application.Ports.Repositories.Provider;
using ADMIN.Core.Entities.Provider;

//using SharedLibrary.Models.Admin.Provider;
//using SharedLibrary.Repositories.Admin.Interface.Provider;

namespace ADMIN.Application.Ports.Services.Interfaces.Provider
{
    public interface IProviderService : IProviderRepository
    {
        AdminResponse GetAll();
        AdminResponse Find(ulong id);
        AdminResponse AddProvider(ProviderRequest request);
        AdminResponse UpdateProvider(ulong id, ProviderRequest request);
        AdminResponse DeleteProvider(ulong id);
        AdminProvider PrepareData(ProviderRequest request, AdminProvider? adminProvider = null);
    }
}
