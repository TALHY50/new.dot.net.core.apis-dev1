using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtCorridorRepository
    {
        Corridor? Add(Corridor corridor);
        Corridor? Update(Corridor corridor);
        List<Corridor> GetAll();
        bool Delete(Corridor corridor);
        Corridor? FindById(uint id);
    }
}
