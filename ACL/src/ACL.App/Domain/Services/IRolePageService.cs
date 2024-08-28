using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;

namespace ACL.App.Domain.Services
{
    public interface IRolePageService : IRolePageRepository
    {
         /// <inheritdoc/>
        Task<ScopeResponse> GetAllById(ulong Id);
        /// <inheritdoc/>
        Task<ScopeResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
        /// <inheritdoc/>
        RolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
    }
}
