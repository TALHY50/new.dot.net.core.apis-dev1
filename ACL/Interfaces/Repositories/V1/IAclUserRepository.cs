using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclUserRepository
    {
        AclResponse GetAll();
        Task<AclResponse> Add(AclUserRequest request);
        AclResponse Edit(ulong id, AclUserRequest request);
        AclResponse findById(ulong id);
        AclResponse deleteById(ulong id);
    }
}
