using SharedKernel.Application.Interfaces;
using SharedKernel.Domain.IMT;

namespace IMT.Application.Application.Ports.Repositories
{
    public interface IImtQuotationRepository : IGenericRepository<ImtQuotation>
    {
        public ImtQuotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
