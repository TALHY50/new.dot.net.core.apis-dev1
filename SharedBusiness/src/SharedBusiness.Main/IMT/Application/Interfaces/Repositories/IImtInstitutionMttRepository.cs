using SharedBusiness.Main.IMT.Domain.Entities;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtInstitutionMttRepository
    {
        InstitutionMtt? Add(InstitutionMtt institutionMtt);
        InstitutionMtt? Update(InstitutionMtt institutionMtt);
        List<InstitutionMtt> GetAll();
        bool Delete(InstitutionMtt institutionMtt);
        InstitutionMtt? FindById(uint id);
    }
}
