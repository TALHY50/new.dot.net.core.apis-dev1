using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;

namespace ACL.App.Domain.Services
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
