using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class WalletLogRepository : GenericRepository<WalletLog>, IWalletLogRepository
{
    public WalletLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}