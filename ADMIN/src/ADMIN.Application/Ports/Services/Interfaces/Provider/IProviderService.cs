using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMIN.Application.Ports.Repositories.Interface;
using ADMIN.Application.Ports.Repositories.Interface.Provider;
using ADMIN.Contracts.Requests;
using ADMIN.Contracts.Response;
using ADMIN.Core.Entities.AdminProvider;

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
