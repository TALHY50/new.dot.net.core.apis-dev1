using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class IncomingWalletEventRepository : GenericRepository<IncomingWalletEvent>, IIncomingWalletEventRepository
{
    public IncomingWalletEventRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}