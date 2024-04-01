using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class CurrencyRepository : GenericRepository<Models.Currency>, ICurrencyRepository
{
    public CurrencyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public Models.Currency? FindByCode(string code)
    {
        return UnitOfWork.ApplicationDbContext.Currencies.FirstOrDefault(c => c.Code == code);
    }

    public Currency? FindById(int? id)
    {
       return UnitOfWork.ApplicationDbContext.Currencies.FirstOrDefault(x => x.Id == id);
    }
}