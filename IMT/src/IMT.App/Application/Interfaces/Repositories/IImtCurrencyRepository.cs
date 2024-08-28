using IMT.App.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace IMT.App.Application.Interfaces.Repositories
{
    public interface IImtCurrencyRepository : IGenericRepository<Currency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}
