using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces.Repositories
{
    public interface ICurrencyConversionRateRepository : IGenericRepository<Models.CurrencyConversionRate>
    {
        public Models.CurrencyConversionRate? FindById(string? id);
       
    }
}
