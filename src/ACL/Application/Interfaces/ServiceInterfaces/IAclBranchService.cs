using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;

namespace ACL.Application.Interfaces.ServiceInterfaces
{
    public interface IAclBranchService : IAclBranchRepository
    {
        Task<AclResponse> Get();
        Task<AclResponse> Add(AclBranchRequest request);
        Task<AclResponse> Edit(ulong id, AclBranchRequest request);
        Task<AclResponse> Find(ulong id);
        Task<AclResponse> Delete(ulong id);
    }
}
