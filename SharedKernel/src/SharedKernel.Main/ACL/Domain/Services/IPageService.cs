using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.ACL.Domain.Entities;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public interface IPageService : IPageRepository
    {
         /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse AddAclPage(AclPageRequest request);
        /// <inheritdoc/>
        ScopeResponse EditAclPage(AclPageRequest aclPageRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(ulong id);
        /// <inheritdoc/>
        ScopeResponse PageRouteCreate(AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        ScopeResponse PageRouteEdit(ulong id, AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        ScopeResponse PageRouteDelete(ulong id);
        /// <inheritdoc/>
        PageRoute PreparePageRouteInputData(AclPageRouteRequest aclPageRouteRequest, PageRoute? aclPageRoute = null);

    }
}
