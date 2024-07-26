using SharedKernel.Main.Application.Interfaces;

namespace IMT.App.Application.Ports.Repositories
{
    public interface IImtCurrencyRepository : IGenericRepository<SharedKernel.Main.Domain.IMT.ImtCurrency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}
