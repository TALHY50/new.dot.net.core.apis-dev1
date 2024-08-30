using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtCurrencyRepository : IGenericRepository<Currency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}
