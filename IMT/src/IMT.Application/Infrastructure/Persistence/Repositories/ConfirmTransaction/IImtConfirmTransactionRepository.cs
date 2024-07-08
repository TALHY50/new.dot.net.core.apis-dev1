﻿
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Services;

namespace IMT.Application.Domain.Ports.Repositories.ConfirmTransaction
{
    public class ImtConfirmTransactionRepository(ApplicationDbContext dbContext) : GenericRepository<ImtProviderErrorDetail, ApplicationDbContext>(dbContext), IImtConfirmTransactionRepository
    {
    }
}
