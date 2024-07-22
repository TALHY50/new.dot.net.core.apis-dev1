﻿using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtCountry
{
    public class ImtCountryRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.ImtCountry, ApplicationDbContext>(dbContext), IImtCountryRepository
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
