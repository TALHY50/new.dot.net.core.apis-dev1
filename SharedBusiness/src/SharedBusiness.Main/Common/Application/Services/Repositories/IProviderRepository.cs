using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IProviderRepository
    {
        Provider? Add(Provider provider);
        Provider? Update(Provider provider);
        bool Delete(Provider provider);
        Provider? View(uint id);
        IEnumerable<Provider>? GetAll();
    }
}
