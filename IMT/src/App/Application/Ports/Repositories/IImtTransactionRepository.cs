using SharedKernel.Application.Interfaces;

namespace App.Application.Ports.Repositories
{
    public interface IImtTransactionRepository : IGenericRepository<SharedKernel.Domain.IMT.ImtTransaction>
    {
    }
}
