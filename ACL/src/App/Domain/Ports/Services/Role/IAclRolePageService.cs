using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Ports.Repositories.Role;
using ACL.Application.Domain.Role;

namespace ACL.Application.Domain.Ports.Services.Role
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
