using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Module;
using ACL.Application.Domain.Ports.Repositories.Module;

namespace ACL.Application.Domain.Ports.Services.Module
{
    public interface IAclPageService : IAclPageRepository
    {
         /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse AddAclPage(AclPageRequest request);
        /// <inheritdoc/>
        AclResponse EditAclPage(AclPageRequest aclPageRequest);
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
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest aclPageRouteRequest, AclPageRoute? aclPageRoute = null);

    }
}
