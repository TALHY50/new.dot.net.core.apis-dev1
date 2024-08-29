using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtServiceMethodRepository
    {
        ServiceMethod? Add(ServiceMethod serviceMethod);
        List<ServiceMethod>? ViewAll();
        ServiceMethod? View(uint id);
        bool Delete(ServiceMethod serviceMethod);
        ServiceMethod? Update(ServiceMethod serviceMethod);
    }
}
