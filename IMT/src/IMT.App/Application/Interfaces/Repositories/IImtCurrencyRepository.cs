using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.IMT.Domain.Entities;

namespace SharedKernel.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtCurrencyRepository : IGenericRepository<Currency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}
