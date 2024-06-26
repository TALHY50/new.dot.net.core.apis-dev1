using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Application.Ports.Services.Module
{
    public interface IAclModuleService : IAclModuleRepository
    {
        /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse AddAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        AclResponse EditAclModule(AclModuleRequest request);
        /// <inheritdoc/>
        AclResponse DeleteModule(ulong id);
    }
}
