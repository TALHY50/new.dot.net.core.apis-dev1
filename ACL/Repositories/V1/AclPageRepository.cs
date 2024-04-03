
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests.V1;

namespace ACL.Repositories.V1
{
    public class AclPageRepository : GenericRepository<AclPage>, IAclPageRepository
    {

        public AclPageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AclPage FindById(ulong Id)
        {
            throw new NotImplementedException();
        }

        public AclPage FindByModuleId(ulong ModuleId)
        {
            throw new NotImplementedException();
        }

        public AclPage FindBySubModuleId(ulong ModuleId)
        {
            throw new NotImplementedException();
        }

        public IList<AclPage> GetAll()
        {
            return UnitOfWork.ApplicationDbContext.AclPages.ToList();
        }

        public bool IsModuleIdExist(ulong ModuleId)
        {
            throw new NotImplementedException();
        }

        public bool IsSubModuleIdExist(ulong SubModuleId)
        {
            throw new NotImplementedException();
        }

        public AclPage PrepareInputData(AclPageRequest request, ulong? id)
        {
            AclPage AclPage = new AclPage();
            if (id == null)
            {

            }
            return AclPage;
        }

    }


}
