using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories
{
    public interface ITmpObjectStorageRepository : IGenericRepository<TmpObjectStorage>
    {

        public TmpObjectStorage FindByOrderId(string orderId);
    }
}
