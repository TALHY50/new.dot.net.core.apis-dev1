using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IInstitutionFundRepository
    {
        InstitutionFund? Add(InstitutionFund institutionFund);
        List<InstitutionFund>? ViewAll();
        InstitutionFund? View(uint id);
        bool Delete(InstitutionFund institutionFund);
        InstitutionFund? Update(InstitutionFund institutionFund);
    }
}
