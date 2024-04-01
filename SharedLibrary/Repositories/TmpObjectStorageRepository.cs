using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using Currency = SharedLibrary.Models.Currency;

namespace SharedLibrary.Repositories
{
    public class TmpObjectStorageRepository : GenericRepository<TmpObjectStorage>, ITmpObjectStorageRepository
    {

        public TmpObjectStorageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }



        public TmpObjectStorage? FindByOrderId(string orderId)
        {
            var self = UnitOfWork.ApplicationDbContext.TmpObjectStorages;
            return self.FirstOrDefault(x => x.OrderId == orderId);
        }
        
    }
}
