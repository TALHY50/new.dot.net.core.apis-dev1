using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;

namespace ACL.App.Domain.Services
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
