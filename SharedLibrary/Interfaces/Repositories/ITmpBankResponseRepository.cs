using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ITmpBankResponseRepository : IGenericRepository<TmpBankResponse>
{

    public TmpBankResponse? FindByOrderId(string orderId);

}