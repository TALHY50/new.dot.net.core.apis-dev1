using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IStateService : IStateRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse Add(AclStateRequest stateRequest);
        /// <inheritdoc/>
        ApplicationResponse Edit(uint id, AclStateRequest stateRequest);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse DeleteById(uint id);
    }
}
