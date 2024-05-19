using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;

namespace ACL.Application.Ports.Repositories
{
    /// <inheritdoc/>
    public interface IAclPageRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse AddAclPage(AclPageRequest request);
        /// <inheritdoc/>
        AclResponse EditAclPage(ulong id, AclPageRequest aclPageRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
        /// <inheritdoc/>
        AclResponse PageRouteCreate(AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        AclResponse PageRouteEdit(ulong id, AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        AclResponse PageRouteDelete(ulong id);
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
