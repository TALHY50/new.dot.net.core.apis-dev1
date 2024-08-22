using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Role;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Role;

namespace SharedKernel.Main.Domain.ACL.Services.Role
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
