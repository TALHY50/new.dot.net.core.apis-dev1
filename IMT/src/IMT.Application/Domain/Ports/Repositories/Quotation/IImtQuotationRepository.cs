using SharedLibrary.Models.IMT;
using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Repositories.Quotation
{
    public interface IImtQuotationRepository : IGenericRepository<ImtQuotation>
    {
        public ImtQuotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
