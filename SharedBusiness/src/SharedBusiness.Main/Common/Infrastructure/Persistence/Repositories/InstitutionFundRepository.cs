﻿using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class InstitutionFundRepository(ApplicationDbContext dbContext) : EfRepository<InstitutionFund>(dbContext),IInstitutionFundRepository
    {
    }
}
