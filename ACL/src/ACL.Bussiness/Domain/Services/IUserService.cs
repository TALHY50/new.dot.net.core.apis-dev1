using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
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
