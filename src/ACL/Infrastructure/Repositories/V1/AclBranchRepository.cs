using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclBranchRepository : GenericRepository<AclBranch, ApplicationDbContext, ICustomUnitOfWork>, IAclBranchRepository
    {
        public AclBranchRepository(ICustomUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ApplicationDbContext)
        {
        }
    }
}
