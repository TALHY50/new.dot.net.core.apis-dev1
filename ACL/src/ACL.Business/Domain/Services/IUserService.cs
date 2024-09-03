using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Domain.Services
{
    public interface IUserService : IUserRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        Task<ScopeResponse> AddUser(AclUserRequest request);
        /// <inheritdoc/>
        Task<ScopeResponse> Edit(uint id, AclUserRequest request);
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(uint id);
        /// <inheritdoc/>
        public User PrepareInputData(AclUserRequest request, User? aclUser = null);
    }
}
