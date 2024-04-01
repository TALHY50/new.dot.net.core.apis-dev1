using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IWalletRepository : IGenericRepository<Wallet>
{

    public Wallet? GetUserWalletByLock(int userId, int? currencyId, bool withLock);
    

}