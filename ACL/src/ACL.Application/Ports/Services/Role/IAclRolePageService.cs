using ACL.Application.Ports.Repositories.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Application.Ports.Services.Role
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
