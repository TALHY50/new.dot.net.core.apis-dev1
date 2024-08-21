using ACL.App.Application.Interfaces.Repositories.Auth;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;

namespace ACL.App.Application.Interfaces.Services.Auth
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
