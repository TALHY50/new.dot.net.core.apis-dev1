using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Interfaces;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclBranchRepository : IGenericRepository<AclBranch>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddBranch(AclBranchRequest request);
        Task<AclResponse> EditBranch(ulong id, AclBranchRequest request);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
    }
}
