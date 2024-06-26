using ACL.Application.Ports.Repositories.Auth;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Application.Ports.Services.Auth
{
    public interface IAclUserService : IAclUserRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        Task<AclResponse> AddUser(AclUserRequest request);
        /// <inheritdoc/>
        Task<AclResponse> Edit(ulong id, AclUserRequest request);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
          /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
        /// <inheritdoc/>
    }
}
