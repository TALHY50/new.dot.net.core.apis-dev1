using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IQuotationRepository : IGenericRepository<Quotation>
    {
        public Quotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
