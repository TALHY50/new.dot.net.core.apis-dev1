using IMT.Application.Domain.Ports.Services.Quotation;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Infrastructure.Persistence.Repositories.ImtCountry
{
    public class ImtCountryRepository(ApplicationDbContext dbContext) : GenericRepository<SharedLibrary.Models.IMT.ImtCountry, ApplicationDbContext>(dbContext), IImtCountryRepository
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
