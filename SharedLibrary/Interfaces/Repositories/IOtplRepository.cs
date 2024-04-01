using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces.Repositories
{
    public interface IOtplRepository : IGenericRepository<Otpl>
    {
        public List<Otpl> GetByMerchantId();
       
    }
}
