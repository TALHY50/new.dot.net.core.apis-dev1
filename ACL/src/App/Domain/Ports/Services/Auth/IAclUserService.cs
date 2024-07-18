using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Auth;

namespace App.Domain.Ports.Services.Auth
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
