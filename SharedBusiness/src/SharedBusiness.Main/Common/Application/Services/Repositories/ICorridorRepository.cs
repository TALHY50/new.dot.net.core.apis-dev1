using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ICorridorRepository
    {
        Corridor? Add(Corridor corridor);
        Corridor? Update(Corridor corridor);
        List<Corridor> GetAll();
        bool Delete(Corridor corridor);
        Corridor? FindById(uint id);
    }
}
