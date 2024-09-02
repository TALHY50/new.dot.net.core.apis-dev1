using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ICorridorRepository : IRepository<Corridor>, IExtendedRepositoryBase<Corridor>
    {
        //Corridor? Add(Corridor corridor);
        //Corridor? Update(Corridor corridor);
        //List<Corridor> GetAll();
        //bool Delete(Corridor corridor);
        //Corridor? FindById(uint id);
    }
}
