using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclPageRepository : IGenericRepository<AclPage>
    {
        AclResponse GetAll();
        AclResponse AddAclPage(AclPageRequest request);
        AclResponse EditAclPage(ulong id, AclPageRequest request);
        AclResponse FindById(ulong id);
        AclResponse DeleteById(ulong id);
        AclResponse PageRouteCreate(AclPageRouteRequest request);
        AclResponse PageRouteEdit(ulong id, AclPageRouteRequest request);
        AclResponse PageRouteDelete(ulong id);
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null);

    }
}
