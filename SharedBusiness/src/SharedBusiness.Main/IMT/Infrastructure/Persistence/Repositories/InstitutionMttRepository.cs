using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class InstitutionMttRepository(ApplicationDbContext dbContext) : IImtInstitutionMttRepository
    {
        public InstitutionMtt? Add(InstitutionMtt institutionMtt)
        {
            throw new NotImplementedException();
        }

        public bool Delete(InstitutionMtt institutionMtt)
        {
            throw new NotImplementedException();
        }

        public InstitutionMtt? FindById(uint id)
        {
            throw new NotImplementedException();
        }

        public List<InstitutionMtt> GetAll()
        {
            throw new NotImplementedException();
        }

        public InstitutionMtt? Update(InstitutionMtt institutionMtt)
        {
            throw new NotImplementedException();
        }
    }
}
