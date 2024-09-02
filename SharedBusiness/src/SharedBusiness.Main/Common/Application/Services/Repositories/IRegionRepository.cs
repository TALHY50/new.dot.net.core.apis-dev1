using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IRegionRepository
    {
        Region? Add(Region region);
        Region? Update(Region region);
        bool Delete(Region region);
        Region? View(uint id);
        IEnumerable<Region>? GetAll();
    }
}
