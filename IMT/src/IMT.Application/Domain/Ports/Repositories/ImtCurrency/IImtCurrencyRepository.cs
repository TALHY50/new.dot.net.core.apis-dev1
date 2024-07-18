using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Application.Interfaces;

namespace IMT.Application.Domain.Ports.Repositories.ImtCurrency
{
    public interface IImtCurrencyRepository : IGenericRepository<SharedKernel.Domain.IMT.ImtCurrency>
    {
        public string? GetCurrencyCodeById(int id);

       public int? GetCurrencyIdByCode(string currencyIsoCode);
    }
}
