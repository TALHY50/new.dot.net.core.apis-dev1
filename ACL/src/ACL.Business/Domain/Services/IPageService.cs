using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface IPageService : IPageRepository
    {
         /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse AddAclPage(AclPageRequest request);
        /// <inheritdoc/>
        ApplicationResponse EditAclPage(AclPageRequest aclPageRequest);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse DeleteById(uint id);
        /// <inheritdoc/>
        ApplicationResponse PageRouteCreate(AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        ApplicationResponse PageRouteEdit(uint id, AclPageRouteRequest aclPageRouteRequest);
        /// <inheritdoc/>
        ApplicationResponse PageRouteDelete(uint id);
        /// <inheritdoc/>
        PageRoute PreparePageRouteInputData(AclPageRouteRequest aclPageRouteRequest, PageRoute? aclPageRoute = null);

    }
}
