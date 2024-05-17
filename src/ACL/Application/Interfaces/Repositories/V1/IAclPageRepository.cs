using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces.Repositories.V1
{
    /// <inheritdoc/>
    public interface IAclPageRepository
    {
        /// <inheritdoc/>
        Task<AclResponse> GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddAclPage(AclPageRequest request);
        /// <inheritdoc/>
        Task<AclResponse> EditAclPage(ulong id, AclPageRequest aclPageRequest);
        /// <inheritdoc/>
        Task<AclResponse> FindById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> DeleteById(ulong id);
        /// <inheritdoc/>
        Task<AclResponse> PageRouteCreate(AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        Task<AclResponse> PageRouteEdit(ulong id, AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        Task<AclResponse> PageRouteDelete(ulong id);
        /// <inheritdoc/>
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest aclPageRouteRequest, AclPageRoute aclPageRoute = null);

        /// <inheritdoc/>
        List<AclPage>? All();
        /// <inheritdoc/>
        AclPage? Find(ulong id);
        /// <inheritdoc/>
        AclPage? Add(AclPage aclPage);
        /// <inheritdoc/>
        AclPage? Update(AclPage aclPage);
        /// <inheritdoc/>
        AclPage? Delete(AclPage aclPage);
        /// <inheritdoc/>
        AclPage? Delete(ulong id);

    }
}
