using ADMIN.Application.Application.Ports.Repositories.Provider;
using ADMIN.Application.Contracts.Requests;
using ADMIN.Application.Contracts.Response;
using ADMIN.Application.Domain.Provider;

//using SharedKernel.Models.Admin.Provider;
//using SharedKernel.Repositories.Admin.Interface.Provider;

namespace ADMIN.Application.Application.Ports.Services.Interfaces.Provider
{
    public interface IProviderService : IProviderRepository
    {
        AdminResponse GetAll();
        AdminResponse Find(ulong id);
        AdminResponse AddProvider(ProviderRequest request);
        AdminResponse UpdateProvider(ulong id, ProviderRequest request);
        AdminResponse DeleteProvider(ulong id);
        Domain.Provider.Provider PrepareData(ProviderRequest request, Domain.Provider.Provider? adminProvider = null);
    }
}
