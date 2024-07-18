using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Application.Application.Ports.Repositories;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace IMT.Application.Infrastructure.Persistence.Repositories.ImtCountry
{
    public class ImtCountryRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Domain.IMT.ImtCountry, ApplicationDbContext>(dbContext), IImtCountryRepository
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId)
        {
           return _dbSet.Find(imtSourceCountryId)?.IsoCode;
        }

        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryIsoCode)
        {
            return _dbSet.Where(c=>c.IsoCode == imtSourceCountryIsoCode)?.ToList().OrderBy(c=>c.Id).LastOrDefault()?.Id;
        }
    }
}
