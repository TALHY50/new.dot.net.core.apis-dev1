using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
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
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(uint id);
        /// <inheritdoc/>
        ScopeResponse PageRouteCreate(AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        ScopeResponse PageRouteEdit(uint id, AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        ScopeResponse PageRouteDelete(uint id);
        /// <inheritdoc/>
        PageRoute PreparePageRouteInputData(AclPageRouteRequest aclPageRouteRequest, PageRoute? aclPageRoute = null);

    }
}
