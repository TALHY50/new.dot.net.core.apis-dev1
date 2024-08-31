using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IInstitutionSettingRepository
    {
        InstitutionAppSetting? Add(InstitutionAppSetting entity);
        InstitutionAppSetting? Update(InstitutionAppSetting entity);
        bool Delete(uint id);
        InstitutionAppSetting? View(uint id);
        IEnumerable<InstitutionAppSetting>? GetAll();
    }
}
