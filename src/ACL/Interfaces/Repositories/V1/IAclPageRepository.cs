using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclPageRepository : IGenericRepository<AclPage>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclPageRequest request);
        Task<AclResponse> Edit(ulong id, AclPageRequest request);
        Task<AclResponse> findById(ulong id);
        Task<AclResponse> deleteById(ulong id);
        Task<AclResponse> PageRouteCreate(AclPageRouteRequest request);
        Task<AclResponse> PageRouteEdit(ulong id, AclPageRouteRequest request);
        Task<AclResponse> PageRouteDelete(ulong id);
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null);

    }
}
