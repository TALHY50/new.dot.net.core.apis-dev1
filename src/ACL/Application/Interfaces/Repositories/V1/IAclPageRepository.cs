using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    public interface IAclPageRepository
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> AddAclPage(AclPageRequest request);
        Task<AclResponse> EditAclPage(ulong id, AclPageRequest request);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
        Task<AclResponse> PageRouteCreate(AclPageRouteRequest request);
        Task<AclResponse> PageRouteEdit(ulong id, AclPageRouteRequest request);
        Task<AclResponse> PageRouteDelete(ulong id);
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null);

    }
}
