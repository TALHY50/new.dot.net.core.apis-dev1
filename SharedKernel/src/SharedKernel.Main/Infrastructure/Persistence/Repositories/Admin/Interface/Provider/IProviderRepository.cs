using SharedKernel.Main.Application.Interfaces;
using SharedKernel.Main.Domain.Admin.Provider;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Admin.Interface.Provider
{
    public interface IProviderRepository : IGenericRepository<Domain.Admin.Provider.Provider>
    {
    }
}