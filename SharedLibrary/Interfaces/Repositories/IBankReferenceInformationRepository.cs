using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IBankReferenceInformationRepository: IGenericRepository<BankReferenceInformation>
{
    
    public BankReferenceInformation? FindByOrderIdAndProvider(string orderId, string provider);
    
}