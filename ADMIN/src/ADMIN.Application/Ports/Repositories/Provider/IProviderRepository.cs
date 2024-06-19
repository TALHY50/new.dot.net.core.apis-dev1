using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADMIN.Contracts.Response;

namespace ADMIN.Application.Ports.Repositories.Provider
{
    public interface IProviderRepository
    {
        AdminResponse GetAll();
    }
}