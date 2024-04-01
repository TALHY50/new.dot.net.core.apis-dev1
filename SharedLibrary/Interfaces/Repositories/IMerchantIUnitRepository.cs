using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantIUnitRepository : IGenericRepository<Merchant>
{
    Task<Merchant> GetMerchantByKey(string merchantKey);

}