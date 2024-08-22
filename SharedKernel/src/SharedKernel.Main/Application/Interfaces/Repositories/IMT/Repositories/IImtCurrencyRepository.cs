﻿using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Domain.IMT.Entities;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories
{
    public interface IImtCurrencyRepository : IGenericRepository<Currency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}