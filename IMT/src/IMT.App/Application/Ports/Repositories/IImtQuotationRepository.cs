using SharedKernel.Main.Application.Interfaces;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Repositories
{
    public interface IImtQuotationRepository : IGenericRepository<ImtQuotation>
    {
        public ImtQuotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
