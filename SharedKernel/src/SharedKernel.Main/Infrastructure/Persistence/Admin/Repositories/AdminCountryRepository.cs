using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Infrastructure.Persistence.Admin.Repositories
{
    public class AdminCountryRepository(ImtApplicationDbContext dbContext) : GenericRepository<Country, ImtApplicationDbContext>(dbContext), IAdminCountryRepository
    {
    }
}
