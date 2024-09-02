using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IMTTRepository
    {
        Mtt? Add(Mtt entity);
        Mtt? Update(Mtt entity);
        bool Delete(uint id);
        Mtt? View(uint id);
        IEnumerable<Mtt>? GetAll();
    }
}
