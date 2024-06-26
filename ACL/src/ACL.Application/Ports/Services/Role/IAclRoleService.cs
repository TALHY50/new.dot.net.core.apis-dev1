using ACL.Application.Ports.Repositories.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Application.Ports.Services.Role
{
    public interface IAclRoleService : IAclRoleRepository
    {
        /// <inheritdoc/>
       AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclRoleRequest roleRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclRoleRequest roleRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
    }
}
