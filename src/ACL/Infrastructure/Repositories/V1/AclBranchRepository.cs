using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclBranchRepository : GenericRepository<AclBranch>, IAclBranchRepository
    {
        public AclBranchRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }
    }
}
