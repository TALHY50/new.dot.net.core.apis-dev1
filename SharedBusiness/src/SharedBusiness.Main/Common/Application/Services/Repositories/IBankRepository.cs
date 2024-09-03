using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IBankRepository : IRepository<Bank>, IExtendedRepositoryBase<Bank>
    {
    }
}
