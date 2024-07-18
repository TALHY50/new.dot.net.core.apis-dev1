using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Company;

namespace App.Domain.Ports.Services.Company
{
    public interface IAclStateService : IAclStateRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclStateRequest stateRequest);
        /// <inheritdoc/>
        AclResponse Edit(ulong id, AclStateRequest stateRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
    }
}
