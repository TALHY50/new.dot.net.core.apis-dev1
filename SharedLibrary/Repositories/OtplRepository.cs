using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public class OtplRepository : GenericRepository<Otpl>, IOtplRepository
    {
        public OtplRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Otpl> GetByMerchantId()
        {
            throw new NotImplementedException();
        }
    }
}
