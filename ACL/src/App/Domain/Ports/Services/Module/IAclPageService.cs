using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Module;
using App.Domain.Ports.Repositories.Module;

namespace App.Domain.Ports.Services.Module
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
