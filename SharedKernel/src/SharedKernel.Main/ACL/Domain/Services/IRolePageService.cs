using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.ACL.Domain.Entities;

namespace SharedKernel.Main.ACL.Domain.Services
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
