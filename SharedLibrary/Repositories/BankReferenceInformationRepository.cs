using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class BankReferenceInformationRepository : GenericRepository<Models.BankReferenceInformation>, IBankReferenceInformationRepository
{
    public BankReferenceInformationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public BankReferenceInformation? FindByOrderIdAndProvider(string orderId, string provider)
    {
        return UnitOfWork.ApplicationDbContext.BankReferenceInformations.FirstOrDefault(s => s.OrderId == orderId && s.Provider == provider);
    }
}