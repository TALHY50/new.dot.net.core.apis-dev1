using SharedKernel.Main.Application.Interfaces;

namespace App.Application.Ports.Repositories
{
    public interface IImtTransactionRepository : IGenericRepository<SharedKernel.Main.Domain.IMT.ImtTransaction>
    {
    }
}
