using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclPageRepository
    {
        AclResponse GetAll();
        AclResponse Add(AclPageRequest request);
        AclResponse Edit(ulong id, AclPageRequest request);
        AclResponse findById(ulong id);
        AclResponse deleteById(ulong id);
    }
}
