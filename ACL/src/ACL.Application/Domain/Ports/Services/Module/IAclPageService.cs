using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Module;
using Notification.Application.Domain.Ports.Repositories.Module;

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
