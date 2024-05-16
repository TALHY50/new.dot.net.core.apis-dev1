using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclBranchRepository
    {
        IEnumerable<AclBranch> All();
        AclBranch GetById(ulong id);
        AclBranch Add(AclBranch entity);
        AclBranch Update(AclBranch entity);
        bool Delete(AclBranch entity);
    }
}
