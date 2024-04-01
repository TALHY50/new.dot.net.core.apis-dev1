using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Exceptions;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Repositories;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    public WalletRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }


    public Wallet? GetUserWalletByLock(int userId, int? currencyId, bool withLock)
    {
        var query = UnitOfWork.ApplicationDbContext.Wallets;
        if (withLock)
        {
            query.FromSqlRaw($"select * from wallets where user_id={userId} and currency_id = {currencyId} for update");
        }
        else
        {
            query.Where(x => x.UserId == userId).Where(x => x.CurrencyId == currencyId);
        }

        return query.FirstOrDefault();
    }
    
}