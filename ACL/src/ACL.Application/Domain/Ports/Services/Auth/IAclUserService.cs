using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Ports.Repositories.Auth;

namespace ACL.Application.Domain.Ports.Services.Auth
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
