using ACL.Application.Ports.Repositories.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Application.Ports.Services.Company
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
