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
    public class DplResourceRepository : GenericRepository<DplResource>, IDplResourceRepository
    {
        public DplResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DplResource? FindByDplId(int dplId)
        {
            return UnitOfWork.ApplicationDbContext.DplResources
                .Where(dplResource => dplResource.DirectPaymentLinkId == dplId)
                .Where(dplResource => dplResource.Status == DplResource.STATUS_ACTIVE)
                .FirstOrDefault();
        }
    }
}
