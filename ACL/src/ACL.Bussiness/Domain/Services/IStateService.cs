using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;

namespace ACL.Bussiness.Domain.Services
{
    public interface IStateService : IStateRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse Add(AclStateRequest stateRequest);
        /// <inheritdoc/>
        ScopeResponse Edit(ulong id, AclStateRequest stateRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(ulong id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(ulong id);
    }
}
