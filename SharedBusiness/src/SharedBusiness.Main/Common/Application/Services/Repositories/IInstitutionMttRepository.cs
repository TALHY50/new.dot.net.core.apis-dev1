using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IInstitutionMttRepository
    {
        InstitutionMtt? Add(InstitutionMtt institutionMtt);
        InstitutionMtt? Update(InstitutionMtt institutionMtt);
        List<InstitutionMtt> GetAll();
        bool Delete(InstitutionMtt institutionMtt);
        InstitutionMtt? FindById(uint id);
    }
}
