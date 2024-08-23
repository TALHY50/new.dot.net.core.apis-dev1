using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories
{
    public class ImtCountryRepository(ApplicationDbContext dbContext) : GenericRepository<Country, ApplicationDbContext>(dbContext), IImtCountryRepository
    {
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId)
        {
            throw new NotImplementedException();
        }

        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId)
        {
            throw new NotImplementedException();
        }
    }
}
