using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantSaleRepository : GenericRepository<MerchantSale>, IMerchantSaleRepository
{
    private IUnitOfWork _unitOfWork;

    public MerchantSaleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public MerchantSale? FindBySaleId(uint saleId)
    {
        return _unitOfWork.ApplicationDbContext.MerchantSales.FirstOrDefault(x => x.SaleId == saleId);
    }
}