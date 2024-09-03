using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IUserService : IUserRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        Task<ApplicationResponse> AddUser(AclUserRequest request);
        /// <inheritdoc/>
        Task<ApplicationResponse> Edit(uint id, AclUserRequest request);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
          /// <inheritdoc/>
        ApplicationResponse DeleteById(uint id);
        /// <inheritdoc/>
    }
}
