using SharedLibrary.Interfaces;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Models.IMT;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Models.Admin.Provider;
using SharedLibrary.Repositories.Admin.Interface.Provider;
using IMT.Application.Domain.Ports.Repositories.Quotation;

namespace IMT.Application.Infrastructure.Persistence.Repositories.Quotation
{
    public class ImtQuotationRepository(ApplicationDbContext dbContext) : GenericRepository<ImtQuotation, ApplicationDbContext>(dbContext), IImtQuotationRepository
    {
    }
}
