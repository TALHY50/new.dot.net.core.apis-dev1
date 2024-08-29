using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtInstitutionFundRepository
    {
        InstitutionFund? Add(InstitutionFund institutionFund);
        List<InstitutionFund>? ViewAll();
        InstitutionFund? View(uint id);
        bool Delete(InstitutionFund institutionFund);
        InstitutionFund? Update(InstitutionFund institutionFund);
    }
}
