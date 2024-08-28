﻿using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class PayerRepository(ApplicationDbContext dbContext)
        : GenericRepository<Payer, ApplicationDbContext>(dbContext), IImtPayerRepository
    {
    }
}