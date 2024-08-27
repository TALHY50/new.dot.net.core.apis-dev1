using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public interface IUserService : IUserRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        Task<ScopeResponse> AddUser(AclUserRequest request);
        /// <inheritdoc/>
        Task<ScopeResponse> Edit(ulong id, AclUserRequest request);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
          /// <inheritdoc/>
        ScopeResponse DeleteById(ulong id);
        /// <inheritdoc/>
    }
}
