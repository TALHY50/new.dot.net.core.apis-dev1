using SharedLibrary.Interfaces;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Models.IMT;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Infrastructure.Persistence.Repositories
{
    public class ImtQuotationRepository : GenericRepository<ImtQuotation, ApplicationDbContext>
    {
        public ImtQuotationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
