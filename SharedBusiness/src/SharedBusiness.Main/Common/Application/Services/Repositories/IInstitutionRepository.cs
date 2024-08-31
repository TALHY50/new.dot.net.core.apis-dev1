using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IInstitutionRepository
    {
        Institution? Add(Institution entity);
        Institution? Update(Institution entity);
        bool Delete(uint id);
        Institution? View(uint id);
        IEnumerable<Institution>? GetAll();
    }
}
