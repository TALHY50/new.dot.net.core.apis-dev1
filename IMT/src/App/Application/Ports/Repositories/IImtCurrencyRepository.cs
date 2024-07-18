using SharedKernel.Application.Interfaces;

namespace IMT.Application.Application.Ports.Repositories
{
    public interface IImtCurrencyRepository : IGenericRepository<SharedKernel.Domain.IMT.ImtCurrency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}
