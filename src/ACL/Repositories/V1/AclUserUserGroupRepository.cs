using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Repositories.V1
{
    public class AclUserUserGroupRepository : GenericRepository<AclUserUsergroup, ApplicationDbContext>, IAclUserUserGroupRepository
    {
        public AclUserUserGroupRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
