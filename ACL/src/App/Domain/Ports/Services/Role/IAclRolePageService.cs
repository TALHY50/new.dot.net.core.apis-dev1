using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Role;
using App.Domain.Role;

namespace App.Domain.Ports.Services.Role
{
    public interface IAclRolePageService : IAclRolePageRepository
    {
         /// <inheritdoc/>
        Task<AclResponse> GetAllById(ulong Id);
        /// <inheritdoc/>
        Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
        /// <inheritdoc/>
        AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest rolePageAssociationRequest);
    }
}
