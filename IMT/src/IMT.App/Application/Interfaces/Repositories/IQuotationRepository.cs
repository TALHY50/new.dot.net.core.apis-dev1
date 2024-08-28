using IMT.App.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace IMT.App.Application.Interfaces.Repositories
{
    public interface IQuotationRepository : IGenericRepository<Quotation>
    {
        public Quotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
