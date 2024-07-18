using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Application.Interfaces;
using SharedKernel.Domain.IMT;

namespace IMT.Application.Domain.Ports.Services.Quotation
{
    public interface IImtCountryRepository : IGenericRepository<ImtCountry>
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId);
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId);
    }
}
