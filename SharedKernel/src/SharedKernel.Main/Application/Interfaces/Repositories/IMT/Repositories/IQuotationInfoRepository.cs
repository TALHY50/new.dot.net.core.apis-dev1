using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories
{
    public interface IQuotationInfoRepository:IGenericRepository<QuotationInfo>
    {
    }
}
