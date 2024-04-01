using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaleAsynchronousProcessRepository : GenericRepository<SaleAsynchronousProcess>, ISaleAsynchronousProcessRepository
{
    public SaleAsynchronousProcessRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}