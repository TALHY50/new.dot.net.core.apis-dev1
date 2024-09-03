using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface ISubModuleService : ISubModuleRepository
    {
         /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse Add(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        ApplicationResponse Edit(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse DeleteById(uint id);
    }
}
