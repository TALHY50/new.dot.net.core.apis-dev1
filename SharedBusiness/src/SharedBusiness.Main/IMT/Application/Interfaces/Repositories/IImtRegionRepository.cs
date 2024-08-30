using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtRegionRepository
    {
        Region? Add(Region region);
        Region? Update(Region region);
        bool Delete(Region region);
        Region? View(uint id);
        IEnumerable<Region>? GetAll();
    }
}
