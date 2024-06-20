using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADMIN.Contracts.Requests;
using ADMIN.Contracts.Response;
using ADMIN.Core.Entities.AdminProvider;

namespace ADMIN.Application.Ports.Repositories.Interface
{
    public interface IProviderRepository
    {
        List<AdminProvider>? All();
        /// <inheritdoc/>
        AdminProvider? Find(ulong id);
        /// <inheritdoc/>
        AdminProvider? Add(ProviderRequest request);
        /// <inheritdoc/>
        AdminProvider? Update(ulong id, ProviderRequest request);
        /// <inheritdoc/>
        AdminProvider? Delete(ulong id);

    }
}