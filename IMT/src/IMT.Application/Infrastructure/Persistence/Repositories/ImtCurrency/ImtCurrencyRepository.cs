using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Infrastructure.Persistence.Repositories.ImtCurrency
{
    public class ImtCurrencyRepository(ApplicationDbContext dbContext) : GenericRepository<SharedLibrary.Models.IMT.ImtCurrency, ApplicationDbContext>(dbContext), IImtCurrencyRepository
    {
        public string? GetCurrencyCodeById(int imtSourceCurrencyId)
        {
            var currency = _dbSet.Find(imtSourceCurrencyId);
            return (currency != null) ? currency.Code : null;
        }
    }
}
