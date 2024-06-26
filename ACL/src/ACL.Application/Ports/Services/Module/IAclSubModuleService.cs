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
    public interface IAclSubModuleService : IAclSubModuleRepository
    {
         /// <inheritdoc/>
        AclResponse GetAll();
        /// <inheritdoc/>
        AclResponse Add(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        AclResponse Edit(AclSubModuleRequest subModuleRequest);
        /// <inheritdoc/>
        AclResponse FindById(ulong id);
        /// <inheritdoc/>
        AclResponse DeleteById(ulong id);
    }
}
