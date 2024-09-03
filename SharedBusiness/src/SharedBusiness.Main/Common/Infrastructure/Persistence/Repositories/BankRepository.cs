using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class BankRepository(ApplicationDbContext dbContext) : EfRepository<Bank>(dbContext), IBankRepository
    {
    }
}
