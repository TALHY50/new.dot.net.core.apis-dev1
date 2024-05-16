using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclStateRepository
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclStateRequest state);
        Task<AclResponse> Edit(ulong id, AclStateRequest state);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);

    }
}
