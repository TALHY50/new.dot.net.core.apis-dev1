﻿using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ICurrencyRepository : IRepository<Currency>, IExtendedRepositoryBase<Currency>
    {

    }
}
