using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class BankRepository : GenericRepository<Bank>, IBankRepository
    {
        
        public BankRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        
        public Bank? FindById(int bank_id){
            return UnitOfWork.ApplicationDbContext.Banks.Where(a=> a.Id == bank_id).FirstOrDefault();
        }

        public Bank? FindByCode(string code)
        {
            return UnitOfWork.ApplicationDbContext.Banks.Where(c => c.Code == code).FirstOrDefault();
        }
    }
}
