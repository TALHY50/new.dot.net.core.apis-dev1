using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface IRolePageService : IRolePageRepository
    {
         /// <inheritdoc/>
        Task<ApplicationResponse> GetAllById(uint Id);
        /// <inheritdoc/>
        Task<ApplicationResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
        /// <inheritdoc/>
        RolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
    }
}
