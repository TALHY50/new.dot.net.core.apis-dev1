using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IModuleService : IModuleRepository
    {
        /// <inheritdoc/>
        ApplicationResponse GetAll();
        /// <inheritdoc/>
        ApplicationResponse FindById(uint id);
        /// <inheritdoc/>
        ApplicationResponse AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        ApplicationResponse EditAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        ApplicationResponse DeleteModule(uint id);
    }
}
