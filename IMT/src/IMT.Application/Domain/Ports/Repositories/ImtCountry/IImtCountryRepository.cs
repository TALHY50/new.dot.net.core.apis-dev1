using SharedLibrary.Interfaces;
using SharedLibrary.Models.IMT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Services.Quotation
{
    public interface IImtCountryRepository : IGenericRepository<ImtCountry>
    {
        public string GetCountryIsoCodeByCountryId(int imtSourceCountryId);
    }
}
