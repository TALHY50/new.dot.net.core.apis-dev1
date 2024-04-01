using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class PosRepository : GenericRepository<Pos>, IPosRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PosRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Pos? FindById(int id)
        {
            return _unitOfWork.ApplicationDbContext.Pos.Find(id);
        }

        
        public Pos FindActivePosById(int posId)
        {
            return _unitOfWork.ApplicationDbContext.Pos.FirstOrDefault(c => c.Id == posId && c.Status == 1)!;
        }
    }
}
