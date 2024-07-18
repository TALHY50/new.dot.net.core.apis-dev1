using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Application.Interfaces;
using SharedKernel.Domain.IMT;

namespace IMT.Application.Domain.Ports.Repositories.Quotation
{
    public interface IImtQuotationRepository : IGenericRepository<ImtQuotation>
    {
        public ImtQuotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
