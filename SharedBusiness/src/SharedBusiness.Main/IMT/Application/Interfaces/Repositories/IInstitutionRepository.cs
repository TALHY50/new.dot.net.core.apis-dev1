using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
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
