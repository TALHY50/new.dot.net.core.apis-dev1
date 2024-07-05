using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Repositories.ImtCurrency
{
    public interface IImtCurrencyRepository : IGenericRepository<SharedLibrary.Models.IMT.ImtCurrency>
    {
        public string? GetCurrencyCodeById(int id);
    }
}
