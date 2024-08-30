using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtProviderRepository
    {
        Provider? Add(Provider provider);
        Provider? Update(Provider provider);
        bool Delete(Provider provider);
        Provider? View(uint id);
        IEnumerable<Provider>? GetAll();
    }
}
