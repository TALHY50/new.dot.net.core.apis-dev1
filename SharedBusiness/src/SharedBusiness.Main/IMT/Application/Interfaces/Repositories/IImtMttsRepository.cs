using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtMttsRepository
    {
        Mtt? Add(Mtt entity);
        Mtt? Update(Mtt entity);
        bool Delete(uint id);
        Mtt? View(uint id);
        IEnumerable<Mtt>? GetAll();
    }
}
