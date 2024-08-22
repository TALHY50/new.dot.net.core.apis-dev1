using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces;
using SharedKernel.Main.Domain.IMT.Entities;

namespace IMT.App.Application.Ports.Repositories
{
    public interface IImtProviderErrorDetailsRepository : IGenericRepository<ProviderErrorDetail>
    {
    }
}
