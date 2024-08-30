using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
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
