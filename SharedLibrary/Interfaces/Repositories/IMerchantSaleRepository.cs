using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantSaleRepository : IGenericRepository<MerchantSale>
{

    public MerchantSale? FindBySaleId(uint saleId);

}