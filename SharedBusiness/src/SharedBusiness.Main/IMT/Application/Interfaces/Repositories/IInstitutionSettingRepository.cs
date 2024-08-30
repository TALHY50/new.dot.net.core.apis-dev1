using SharedBusiness.Main.IMT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
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
