using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Domain.Services
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
