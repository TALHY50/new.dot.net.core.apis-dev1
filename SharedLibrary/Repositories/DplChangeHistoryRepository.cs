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
    public class DplChangeHistoryRepository : GenericRepository<DplChangeHistory>, IDplChangeHistoryRepository
    {
        public DplChangeHistoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
