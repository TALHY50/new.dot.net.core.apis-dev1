using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IServiceMethodRepository
    {
        ServiceMethod? Add(ServiceMethod serviceMethod);
        List<ServiceMethod>? ViewAll();
        ServiceMethod? View(uint id);
        bool Delete(ServiceMethod serviceMethod);
        ServiceMethod? Update(ServiceMethod serviceMethod);
    }
}
