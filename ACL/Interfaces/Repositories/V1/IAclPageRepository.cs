using ACL.Database.Models;
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
        AclResponse PageRouteCreate(AclPageRouteRequest request);
        AclResponse PageRouteEdit(ulong id, AclPageRouteRequest request);
        AclResponse PageRouteDelete(ulong id);
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null);

    }
}
