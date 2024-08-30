using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Domain.Services
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
