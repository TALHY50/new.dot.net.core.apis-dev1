using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Ports.Repositories.Role;
using ACL.App.Domain.Role;

namespace ACL.App.Domain.Ports.Services.Role
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
