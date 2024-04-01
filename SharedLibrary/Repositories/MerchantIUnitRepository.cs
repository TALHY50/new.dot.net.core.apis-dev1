using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantIUnitRepository : GenericRepository<Merchant>, IMerchantIUnitRepository
{
    public MerchantIUnitRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Merchant> GetMerchantByKey(string merchantKey)
    {
        try
        {
            
            return await UnitOfWork.ApplicationDbContext.Merchants.FirstOrDefaultAsync(x => x.MerchantKey == merchantKey);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}